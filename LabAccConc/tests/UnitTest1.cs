using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using LabAccConc;
using System.Threading.Tasks;

namespace tests
{
    
    [TestClass]
    public class UnitTest1
    {
        private CompanyContext _context;
        [TestInitialize]
        public void Setup()
        {
            DbContextOptionsBuilder builder=new DbContextOptionsBuilder();
            DbContextOptions options= builder.UseSqlServer(@"Data Source=localhost,1433;Initial Catalog=LabAccConc;User Id=sa;Password=yourStrong(!)Password;").Options;
            _context=new CompanyContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _context.Customers.Add(new Customer(){
                AccountBalance=12,
                Name="John Doe"
            });
            _context.SaveChanges();
        }

        [TestMethod]
        public async Task CanRetrieveDataAsync()
        {
            Customer customer= await _context.Customers.SingleAsync(c=>c.Name=="John Doe");
            Assert.AreEqual(12,customer.AccountBalance);
        }
    }
}
