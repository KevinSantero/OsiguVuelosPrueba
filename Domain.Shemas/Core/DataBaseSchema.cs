
namespace Domain.Shemas.Core
{
    public static class DataBaseSchema
    {
        public static readonly string schema = "dbo";
        public static readonly int commandTimeout = 3600; //Segundos
        public static string BuildTableName(string tableName)
        {
            return $"{schema}.{tableName}";
        }
        public static string GetTableName(string tableName)
        {
            return tableName.Replace(schema + ".", "");
        }

        public static string BuildMasterTableName(string tableName)
        {
            return tableName + "Master";
        }

        public static string BuildRawTableName(string tableName)
        {
            return $"\"{schema}\".\"{tableName}\"";
        }

        public static string FieldName(this string tableName)
        {
            var parts = tableName.Split(".");
            return parts[parts.Length - 1];
        }

        public static string RemoveSchema(this string tableName)
        {
            return tableName.Replace(schema + ".", "");
        }
#pragma warning restore CS1591 // Falta el comentario XML para el tipo o miembro visible públicamente
    }
}
