using _DotNETCore_7_ADO_Sp_.Models;

namespace _DotNETCore_7_ADO_Sp_.VService
{
    public interface IVisitor_Service
    {
        public List<Visitor> GetVisitorsList();
        public IEnumerable<Visitor>  GetVisitorById(int Id);
        public int AddProduct(Visitor v);
        public int UpdateProduct(Visitor v);
        public int DeleteProduct(int Id);
    }
}
