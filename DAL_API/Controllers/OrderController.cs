using System;
using System.Collections.Generic;
using System.Web.Http;
using DAL;
using DAL.DTOModels;

namespace DAL_API.Controllers
{
    public class OrderController : ApiController
    {
        internal class OrderRepository : GenericRepository<OrderDTO>
        {
            public override OrderDTO Get(DGHEntities db, int id)
            {
                var product = db.Products.FirstOrDefault(x => x.id == id);
                if (product != null)
                    return new ProductDTO
                    {
                        id = product.id,
                        name = product.name,
                        productNumber = product.productNumber,
                        color = product.color,
                        stock = product.stock,
                        salesPrice = product.salesPrice
                    };
                return null;
            }

            public override IEnumerable<ProductDTO> GetAll(DGHEntities db)
            {
                return db.Products.Select(tempProduct => new ProductDTO()
                {
                    id = tempProduct.id,
                    name = tempProduct.name,
                    productNumber = tempProduct.productNumber,
                    color = tempProduct.color,
                    stock = tempProduct.stock,
                    salesPrice = tempProduct.salesPrice
                }).ToList();
            }

            public override void Add(DGHEntities db, ProductDTO productDTO)
            {
                if (productDTO == null) throw new ArgumentNullException("productDTO");
                var product = new Product
                {
                    id = productDTO.id,
                    name = productDTO.name,
                    productNumber = productDTO.productNumber,
                    color = productDTO.color,
                    stock = productDTO.stock,
                    salesPrice = productDTO.salesPrice,
                };
                db.Products.Add(product);
                db.SaveChanges();
            }

            public override void Update(DGHEntities db, ProductDTO productDTO)
            {
                if (productDTO == null) throw new ArgumentNullException("productDTO");
                var product = new Product
                {
                    id = productDTO.id,
                    name = productDTO.name,
                    productNumber = productDTO.productNumber,
                    color = productDTO.color,
                    stock = productDTO.stock,
                    salesPrice = productDTO.salesPrice,
                };
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }

            public override void Delete(DGHEntities db, int id)
            {
                db.Products.Remove(db.Products.FirstOrDefault(x => x.id == id));
                db.SaveChanges();
            }
        }
    }
}
