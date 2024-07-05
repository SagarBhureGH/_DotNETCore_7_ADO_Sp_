using _DotNETCore_7_ADO_Sp_.Contexts;
using _DotNETCore_7_ADO_Sp_.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace _DotNETCore_7_ADO_Sp_.VService
{
    public class VisitorService : IVisitor_Service
    {
        //[dbo].[getAllData][dbo].[getDataById][dbo].[deleteById][dbo].[insertData][dbo].[updateData]

        private readonly MyDbContext dbContext;

        public VisitorService(MyDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public int AddProduct(Visitor v)
        {
            
            var sqlparam=new List<SqlParameter>();
            sqlparam.Add(new SqlParameter("@Name",v.Name));
            sqlparam.Add(new SqlParameter("@Address", v.Address));
            sqlparam.Add(new SqlParameter("@Mobile", v.Mobile));
            sqlparam.Add(new SqlParameter("@RegisterAt", v.RegisterAt));
            sqlparam.Add(new SqlParameter("@DepartAt", v.DepartAt));

            var reult = dbContext.Database.ExecuteSqlRaw(@"EXEC insertData @Name, @Address, @Mobile, @RegisterAt, @DepartAt", sqlparam.ToArray());
            return reult;
        }

        public  int DeleteProduct(int Id)
        {
            var data = dbContext.Database.ExecuteSqlInterpolated($"deleteById {Id}");
            //return await Task.Run(() => dbContext.Database.ExecuteSqlInterpolatedAsync($"deleteById {Id}"));
            return data;
        }

        public IEnumerable<Visitor> GetVisitorById(int Id)
        {
            var param = new SqlParameter("@Id", Id);
            var data = dbContext.Visitors.FromSqlRaw(@"exec getDataById @Id", param).ToList();
            return data;
        }

        public List<Visitor> GetVisitorsList()
        {
            var data = dbContext.Visitors.FromSqlRaw<Visitor>("getAllData").ToList();
            return data;
        }

        public int UpdateProduct(Visitor v)
        {
            var sqlparam = new List<SqlParameter>();
            sqlparam.Add(new SqlParameter("@Id", v.Id));
            sqlparam.Add(new SqlParameter("@Name", v.Name));
            sqlparam.Add(new SqlParameter("@Address", v.Address));
            sqlparam.Add(new SqlParameter("@Mobile", v.Mobile));
            sqlparam.Add(new SqlParameter("@RegisterAt", v.RegisterAt));
            sqlparam.Add(new SqlParameter("@DepartAt", v.DepartAt));

            var result = dbContext.Database.ExecuteSqlRaw(@"EXEC updateData @Id, @Name, @Address, @Mobile, @RegisterAt, @DepartAt ", sqlparam.ToArray());
            return result;
        }
    }
}
