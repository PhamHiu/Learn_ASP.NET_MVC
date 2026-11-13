using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers.Web
{
    public class DemoController : Controller
    {
        public string Hello()
        {
            return "HiuHiu - SE08201";

            // hien thi thong tin nay ra ngoai trinh duyet
            // https://localhost:7034/Demo/Hello
            // https://localhost:7034 : ten mien + port
            // Demo : ten cua controller(luôn bỏ hậu tố controller)
            // Hello : ten phuong thuc
        }
        public string Product (int id , string name, float price )
        {
            return $"Product : id = {id}   name:  {name}, price : {price}";

            // https://localhost:7034/demo/product?id=10&name=hiuhiu&price=10000
            // truyền dữ liệu bang phuong thuc get  
            // ? : bắt đầu các tham số 
            // <tên biến >= <giá trị >
            // & nhiều tham số nối tiếp nhau 
        }
    }
}
