using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Tano.EntityFramework.Context;
using EntityState = System.Data.Entity.EntityState;

namespace Tano.EntityFramework
{
    public interface IBaseRepository<T> where T : class //ObjectEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> Get(Func<T, bool> predicate);
        T Find(params object[] key);
        void Atualizar(T obj);
        void SalvarTodos();
        void Adicionar(T obj);
        void Excluir(Func<T, bool> predicate);
        IEnumerable<T> ExecuteProcedure(RepositoryParam parametros);
        string ExecuteProcedureScalar(RepositoryParam parametros);
        IEnumerable<F> ExecuteProcedureWithoutType<F>(RepositoryParam parametros);
    }

    public class RepositoryParam
    {
        public string ProcedureName { get; set; }
        public Dictionary<object, object> Params { get; set; }
    }




    public abstract class BaseRepositorio<T> : IDisposable, IBaseRepository<T> where T : class
    {
        private ContextDb<T> _ctx;

        public IEnumerable<T> ExecuteProcedure(RepositoryParam parametros)
        {
            var paramObj = new List<SqlParameter>();
            var paramQuery = string.Empty;

            if (parametros.Params != null)
            {
                foreach (KeyValuePair<object, object> pair in parametros.Params)
                {
                    if (pair.Value != null)
                    {
                        paramQuery = paramQuery + pair.Key + ((string)pair.Key == "@MSG_ERRO" ? " out" : "") + ",";
                        paramObj.Add(new SqlParameter()
                        {
                            ParameterName = pair.Key.ToString(),
                            Value = pair.Value,
                            Direction =
                                ((string)pair.Key == "@MSG_ERRO" ? ParameterDirection.Output : ParameterDirection.Input),
                            Size = ((string)pair.Key == "@MSG_ERRO" ? 255 : pair.Value.ToString().Length)
                        });
                    }
                }
            }
            
            var arrayParameters = paramObj.ToArray();
            _ctx.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            

            if (arrayParameters.Length > 0)
            {
                return
                    _ctx.Database.SqlQuery<T>(
                        parametros.ProcedureName + " " + paramQuery.Substring(0, paramQuery.Count() - 1),
                        arrayParameters).ToList();
            }
            else
            {
                return
                    _ctx.Database.SqlQuery<T>(
                        parametros.ProcedureName).ToList();
            }

        }

        public IEnumerable<F> ExecuteProcedureWithoutType<F>(RepositoryParam parametros)
        {
            var paramObj = new List<SqlParameter>();
            var paramQuery = string.Empty;

            foreach (KeyValuePair<object, object> pair in parametros.Params)
            {
                if (pair.Value != null)
                {
                    paramQuery = paramQuery + pair.Key + ((string)pair.Key == "@MSG_ERRO" ? " out" : "") + ",";
                    paramObj.Add(new SqlParameter()
                    {
                        ParameterName = pair.Key.ToString(),
                        Value = pair.Value,
                        Direction =
                            ((string)pair.Key == "@MSG_ERRO" ? ParameterDirection.Output : ParameterDirection.Input),
                        Size = ((string)pair.Key == "@MSG_ERRO" ? 255 : pair.Value.ToString().Length)
                    });
                }
            }

            var arrayParameters = paramObj.ToArray();
            _ctx.Configuration.EnsureTransactionsForFunctionsAndCommands = false;


            if (arrayParameters.Length > 0)
            {
                return
                    _ctx.Database.SqlQuery<F>(
                        parametros.ProcedureName + " " + paramQuery.Substring(0, paramQuery.Count() - 1),
                        arrayParameters).ToList();
            }
            else
            {
                return
                    _ctx.Database.SqlQuery<F>(
                        parametros.ProcedureName).ToList();
            }

        }

        public virtual string ExecuteProcedureScalar(RepositoryParam parametros)
        {
            try
            {
                var paramObj = new List<SqlParameter>();
                var paramQuery = string.Empty;
                var retorno = string.Empty;

                foreach (KeyValuePair<object, object> pair in parametros.Params)
                {
                    if (pair.Value != null)
                    {
                        paramQuery = paramQuery + pair.Key + ((string)pair.Key == "@MSG_ERRO" ? " out" : "") + ",";
                        paramObj.Add(new SqlParameter()
                        {
                            ParameterName = pair.Key.ToString(),
                            Value = pair.Value,
                            Direction = ((string)pair.Key == "@MSG_ERRO" ? ParameterDirection.Output : ParameterDirection.Input),
                            Size = ((string)pair.Key == "@MSG_ERRO" ? 255 : pair.Value.ToString().Length)
                        });
                    }
                }

                var arrayParameters = paramObj.ToArray();
                _ctx.Configuration.EnsureTransactionsForFunctionsAndCommands = false;

                if (arrayParameters.Length > 0)
                {
                    _ctx.Database.ExecuteSqlCommand(
                        parametros.ProcedureName + " " + paramQuery.Substring(0, paramQuery.Count() - 1),
                        arrayParameters);
                }
                else
                {
                    _ctx.Database.ExecuteSqlCommand(
                        parametros.ProcedureName);
                }

                foreach (var o in arrayParameters.Where(o => o.Direction == ParameterDirection.Output))
                {
                    retorno = o.Value.ToString();
                }

                return retorno;
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        protected void Initialize()
        {   
            _ctx = new ContextDb<T>();
            _ctx.Context.Local.Clear();
        }

        public IQueryable<T> GetAll()
        {
            return _ctx.Set<T>();
        }

        public IQueryable<T> Get(Func<T, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public virtual T Find(params object[] key)
        {
            return _ctx.Set<T>().Find(key);
        }

        public void Atualizar(T obj)
        {
            _ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SalvarTodos()
        {
            _ctx.SaveChanges();
        }

        public void Adicionar(T obj)
        {
            _ctx.Set<T>().Add(obj);
        }

        public void Excluir(Func<T, bool> predicate)
        {
            _ctx.Set<T>()
                .Where(predicate).ToList()
                .ForEach(del => _ctx.Set<T>().Remove(del));
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }

    
}
