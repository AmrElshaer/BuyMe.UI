using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMe.Domain.Entities
{
    public class CartItem
    {
        public CartItem(int productId, int qTN,int companyId,int customerId)
        {
            this.ProductId = productId;
            this.CustomerId = customerId;
            this.CompanyId = companyId;
            SetQTN(qTN);
           
        }
        public CartItem() {}
        public void SetQTN(int quantity) => this.QTN = quantity;
        public int Id { get;private set; }
        public int ProductId { get;private set; }
        public Product Product { get;private set; }
        public int CustomerId { get;private set; }
        public Customer Customer { get;private set; }
        public int QTN { get;private set; }
        public int CompanyId { get;private set; }
    }
}
