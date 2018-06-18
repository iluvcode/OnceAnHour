using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;

namespace App3.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
