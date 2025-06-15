using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; //ORM


namespace source.DataBase
{
    internal class ContextDB : DbContext
    {
        //ClaveSQL
        string sqlKey {  get; set; }


        //DBSets (Puntero a tablas)


        //Logica para establecer la conexion a la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
