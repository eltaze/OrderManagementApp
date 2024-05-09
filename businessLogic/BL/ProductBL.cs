using AutoMapper;
using BackEnd.Model;
using BackEnd.UOF;
using businessLogic.Model;
using Microsoft.Extensions.Caching.Memory;


namespace businessLogic.BL
{
    public class ProductBL(IMapper mapper,IUOF uOF,IMemoryCache cache) 
    {
        private readonly IMapper mapper = mapper;
        private readonly IUOF uOF = uOF;
        private readonly IMemoryCache cache = cache;

        public async Task<bool> Add(ProductsUI entity)
        {
            var prod  =mapper.Map<Products>(entity);
          var result= await uOF.product.Add(prod);
            await uOF.ComplateTask();
            return result;
        }

        public async Task<List<ProductsUI>> All()
        {
            var output = cache.Get<List<ProductsUI>>("Products");
            if(output == null || output.Count==0) 
            {
                var result = await uOF.product.All();
                if (result == null) { return null; }
                output = mapper.Map<List<ProductsUI>>(result.ToList());
                cache.Set<List<ProductsUI>>("Products",output,TimeSpan.FromMinutes(15));
            }
            return output;
               
        }
        public async Task<bool> Delete(int id)
        {
           var result = await uOF.product.Delete(id);
            await uOF.ComplateTask();
            return result;
        }

        public async Task<ProductsUI> GetById(int id)
        {
          var result = await uOF.product.GetById(id);
            if (result == null) { return null; }
            return mapper.Map<ProductsUI>(result);
        }
        public async Task<List<ProductsUI>> GetByName(string Id)
        {
           var result =await uOF.product.GetByT(Id, "Name");
            if (result == null) { return null; }
            return mapper.Map<List<ProductsUI>>(result);
        }
        public async Task<bool> Update(ProductsUI entity) 
        {
            var prod = mapper.Map<Products>(entity);
            var result = await uOF.product.Update(prod);
            await uOF.ComplateTask();
            return result;
        }
    }
}
