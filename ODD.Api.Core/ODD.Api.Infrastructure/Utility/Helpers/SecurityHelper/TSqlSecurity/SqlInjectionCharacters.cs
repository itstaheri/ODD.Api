using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.Utility.Helpers.SecurityHelper
{
    public  static class SqlInjectionCharacters
    {
        public static readonly  string[] ForbiddenCharacters = {"Hex", ";", "--", "/*", "*/", "sp_", "xp_", "exec", "execute", "insert", "update", "delete", "select", "union", "where", "and", "or", "not", "case", "when", "if", "else", "end", "truncate", "drop", "create", "alter", "table", "view", "index", "database", "backup", "restore", "declare", "set", "cast", "convert", "nvarchar", "varchar", "char", "nchar", "int", "bigint", "smallint", "tinyint", "float", "real", "decimal", "numeric", "money", "smallmoney", "datetime", "smalldatetime", "timestamp", "binary", "varbinary", "image", "cursor", "fetch", "next", "open", "close", "dealloc" };
    }
}
