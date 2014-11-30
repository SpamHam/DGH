using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.DTOModels;
using DAL.Entities_Converter;


namespace DAL.Repository.Impl
{
    internal class ProductRepository : GenericRepository<ProductDTO>
    {
        public override ProductDTO Get(DGHEntities db, int id)
        {
            return db.Products.Select(ProductConverter.ToProductDTO).FirstOrDefault(x => x.id == id);
            /*
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
            return null;*/
        }

        public override IEnumerable<ProductDTO> GetAll(DGHEntities db)
        {

            return db.Products.Select(ProductConverter.ToProductDTO).ToList();
            /*{
                id = tempProduct.id, 
                name = tempProduct.name, 
                productNumber = tempProduct.productNumber, 
                color = tempProduct.color, 
                stock = tempProduct.stock, 
                salesPrice = tempProduct.salesPrice
            }).ToList();*/
            //return db.Orders.Select(OrderConverter.toOrderDTO).ToList();
        }

        public override void Add(DGHEntities db, ProductDTO productDTO)
        {
            if (productDTO == null) throw new ArgumentNullException("productDTO");
            /*
               var product = new Product
               {
                       id = productDTO.id,
                       name = productDTO.name,
                       productNumber = productDTO.productNumber,
                       color = productDTO.color,
                       stock = productDTO.stock,
                       salesPrice = productDTO.salesPrice,
                   }; if (orderDTO == null) throw new ArgumentNullException("orderDTO");
               db.Orders.Add(OrderConverter.ToOrder(orderDTO));
               db.SaveChanges();*/
            db.Products.Add(ProductConverter.ToProduct(productDTO));
            db.SaveChanges();
        }

        public override void Update(DGHEntities db, ProductDTO productDTO)
        {
            if (productDTO == null) throw new ArgumentNullException("productDTO");
            /*var product = new Product
            {
                id = productDTO.id,
                name = productDTO.name,
                productNumber = productDTO.productNumber,
                color = productDTO.color,
                stock = productDTO.stock,
                salesPrice = productDTO.salesPrice,
            };*/
            db.Entry(ProductConverter.ToProduct(productDTO)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public override void Delete(DGHEntities db, int id)
        {
            db.Products.Remove(db.Products.FirstOrDefault(x => x.id == id));
            db.SaveChanges();
        }
    }
}
