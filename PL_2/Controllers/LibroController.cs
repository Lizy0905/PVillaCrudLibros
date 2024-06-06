using Microsoft.AspNetCore.Mvc;

namespace PL_2.Controllers
{
    public class LibroController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            libro.Libros = new List<ML.Libro>();
            var result = BL.Libro.GetAll();
            if (result.success)
            {
                libro= result.Item3;
            }
            return View(libro);
        }


        public IActionResult Form(ML.Libro libro)
        {
            //ML.Libro libro = new ML.Libro();

            if(libro.IdLibro > 0)
            {
                var resultado = BL.Libro.GetById(libro.IdLibro);
                if (resultado.success)
                {
                    libro = resultado.Item3;
                    return View(libro);
                }
            }
            else
            {
                return View(libro);
            }

            return View(libro);
        }










    }

}
