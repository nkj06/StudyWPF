using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCaliburn.Helpers
{
    class Commons
    {
        public static string STRCONNSTRING =
            "Data Source=localhost;Port=3306;Database=testdb;uid=root;password=0000";

        public static string SELECTPEOPLEQUERY =
            "SELECT id, FirstName, LastName " +
            "  FROM peopletbl " +
            " ORDER BY id ";

    }
}