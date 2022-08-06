using Microsoft.AspNetCore.Mvc;
using FerreteriaMBA.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FerreteriaMBA.Controllers
{
    public class CodigoController : Controller
    {
        private readonly FerreteriaMBA1Context _con;

        public CodigoController(FerreteriaMBA1Context con) {
            _con = con;
        }
        public ActionResult Index()
        {
            double total = 0;
            string codigo = "";
            double axtoatl = 0;
            var presultado = _con.Codigos.Include(c => c.IdProductoNavigation).Where(d => d.Estatus == "true").ToList();
 

            foreach (var item in presultado)
            {

                codigo = item.Codigo1;

            }

            var resultado = _con.Codigos.Include(c => c.IdProductoNavigation).Where(d => d.Estatus == "true" && d.Codigo1 == codigo).ToList();

            foreach (var item in resultado)
            {

                axtoatl = (double)(int.Parse(item.Cantidad) * item.IdProductoNavigation.Precio);
                total = total + axtoatl;
            }

                ViewBag.codigo = codigo;
            ViewBag.Total=  total.ToString("RD$ 0,0.0");
            


            return View( resultado.ToList());
        }

        [HttpPost]
        public ActionResult Add(string? codigo, string cantidad) {

            var codigos = _con.Productos.Where(d => d.Codigo == codigo).ToList();
            int? id_product = 0;

            
            foreach (var item in codigos) {

                id_product = item.IdProducto;
            }
            
           
            Codigo codigo1 = new Codigo();
            codigo1.Codigo1 = general_codigo();
            codigo1.IdProducto = id_product;
            codigo1.Estatus = "true";
            codigo1.Cantidad = cantidad;
            _con.Add(codigo1);
            _con.SaveChanges();




            return View();
        }

   

        public string general_codigo()
        {
            string codigo = "";
            string rcodigo = "";
            var resultado = _con.Codigos.Where(d => d.Estatus == "true").ToList();
            foreach (var item in resultado)
            {

                rcodigo = item.Codigo1;
                

            }
            if (rcodigo == null)
            {

                for (int i = 0; i < 5; i++)
                {
                    codigo += letras_aleatorias();
                }

                for (int i = 0; i < 5; i++)
                {

                    codigo += numeros_aleatorias();
                }

            }
            else {

                codigo = rcodigo;

            
            }

            return codigo;

            Console.WriteLine(codigo);
        }
        #region general codigos
        public string letras_aleatorias()
        {
            Random random = new Random();
            List<string> lista = new List<string>() {
            "a","b","c","d","e","r","z","x","v","b"
            };

            return lista[random.Next(0, 10)].ToUpper();
        }

        public string numeros_aleatorias()
        {
            Random random = new Random();
            List<string> lista = new List<string>() {
            "1","2","3","4","5","6","7","8","9","0"
            };

            return lista[random.Next(0, 10)];
        }
        #endregion

    }
}


