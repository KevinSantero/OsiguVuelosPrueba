using System.Data;
using System.Globalization;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace Aplicacion.Queries
{
    public class BaseQueries : IDisposable
    {
        protected IDbConnection _connection;
        protected readonly Compiler _compiler;
        protected QueryFactory _queryFactory;
        protected string _language;

        public BaseQueries(IDbConnection connection, Compiler compiler)
        {
            _connection = connection;
            _compiler = compiler;
            _queryFactory = new QueryFactory(_connection, _compiler, timeout: 0);
            _language = Thread.CurrentThread.CurrentUICulture.Parent.Name;
        }

        protected void SetLanguage(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            _language = Thread.CurrentThread.CurrentUICulture.Parent.Name;
        }

      
        protected string BuildSqlText(Query query)
        {
            //https://sqlformat.org/
            return _queryFactory.Compiler.Compile(query).Sql;
        }

        protected string BuildRawSqlText(Query query)
        {
            //https://sqlformat.org/
            return _queryFactory.Compiler.Compile(query).RawSql;
        }

        #region --IDisposable--
        public virtual void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
            _queryFactory?.Dispose();
            _connection = null;
            _queryFactory = null;
           // CoreHelper.WaitForPendingFinalizers();
        }
        #endregion
    }
}
