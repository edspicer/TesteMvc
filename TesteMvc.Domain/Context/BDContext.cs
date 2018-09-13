using System.Data.Entity;
using TesteMvc.EF;
namespace TesteMvc.DAL.Context
{
   public class BDContext : BDTesteEntities
    {

        public BDContext()
        {

        }
       
        //public BDContext() : base("name=Entities")
        //{

        //}

       // Somente em codefirst
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        //}
    }
}
