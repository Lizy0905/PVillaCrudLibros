namespace BL
{
    public class Libro
    {

        public static (bool success, string messge, ML.Libro, Exception Error) GetAll()
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.Models.PVillaPruebaContext context = new DL.Models.PVillaPruebaContext())
                {
                    var query = (from Libr in context.Libros
                                 select new
                                 {
                                     IdLibro = Libr.IdLibro,
                                     Titulo = Libr.Titulo,
                                     Autor = Libr.Autor,
                                     Isbn = Libr.Isbn,
                                     FechaPublicacion = Libr.AñoPublicacion
                                 }).ToList();
                    if (query != null)
                    {
                        libro.Libros = new List<ML.Libro>();

                        foreach (var registros in query)
                        {
                            ML.Libro objLibro = new ML.Libro();
                            objLibro.IdLibro = registros.IdLibro;
                            objLibro.Titulo = registros.Titulo;
                            objLibro.Autor = registros.Autor;
                            objLibro.Isbn = registros.Isbn;
                            objLibro.FechaPublicacion = registros.FechaPublicacion;
                            libro.Libros.Add(objLibro);
                        }

                        return (true, "registros encontrados", libro, null);
                    }
                    else
                    {
                        return (false, "registros no encontrados", libro, null);

                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, libro, ex);

            }
        }

        public static (bool success, string messge, ML.Libro, Exception Error) GetById(int idLibro)
        {
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.Models.PVillaPruebaContext context = new DL.Models.PVillaPruebaContext())
                {
                    var query = (from Libr in context.Libros
                                 where Libr.IdLibro == idLibro
                                 select new
                                 {
                                     IdLibro = Libr.IdLibro,
                                     Titulo = Libr.Titulo,
                                     Autor = Libr.Autor,
                                     Isbn = Libr.Isbn,
                                     FechaPublicacion = Libr.AñoPublicacion
                                 }).SingleOrDefault();
                    if (query != null)
                    {


                        ML.Libro objLibro = new ML.Libro();
                        objLibro.IdLibro = query.IdLibro;
                        objLibro.Titulo = query.Titulo;
                        objLibro.Autor = query.Autor;
                        objLibro.Isbn = query.Isbn;
                        objLibro.FechaPublicacion = query.FechaPublicacion;

                        libro = objLibro;

                        return (true, "registros encontrados", libro, null);
                    }
                    else
                    {
                        return (false, "registros no encontrados", libro, null);

                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, libro, ex);

            }
        }

        public static (bool success, string messge, Exception Error) Add(ML.Libro libro)
        {
         
            try
            {
                using (DL.Models.PVillaPruebaContext context = new DL.Models.PVillaPruebaContext())
                {
                    DL.Models.Libro libroLINQ = new DL.Models.Libro();

                    libroLINQ.Titulo = libro.Titulo;
                    libroLINQ.Autor = libro.Autor;
                    libroLINQ.Isbn = libro.Isbn;
                    libroLINQ.AñoPublicacion = libro.FechaPublicacion;

                    context.Libros.Add(libroLINQ);
                    int rowAffected = context.SaveChanges();


                    if(rowAffected > 0)
                    {
                        return (true, "Registro Agregado", null);
                    }
                    else
                    {
                        return (false, "Registro no Agregado", null);

                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, ex);

            }
        }

        //public static (bool success, string messge, Exception Error) Update(ML.Libro libro)
        //{

        //    try
        //    {
        //        using (DL.Models.PVillaPruebaContext context = new DL.Models.PVillaPruebaContext())
        //        {
        //            var query = (from lbr in context.Libros
        //                         where lbr.IdLibro = libro.IdLibro
        //                         select lbr. )
        //docker y cubernetes
        //firma: tipo de retorno, nombre y parametros

        //            DL.Models.Libro libroLINQ = new DL.Models.Libro();

        //            libroLINQ.Titulo = libro.Titulo;
        //            libroLINQ.Autor = libro.Autor;
        //            libroLINQ.Isbn = libro.Isbn;
        //            libroLINQ.AñoPublicacion = libro.FechaPublicacion;

        //            context.Libros.Add(libroLINQ);
        //            int rowAffected = context.SaveChanges();


        //            if (rowAffected > 0)
        //            {
        //                return (true, "Registro Agregado", null);
        //            }
        //            else
        //            {
        //                return (false, "Registro no Agregado", null);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return (false, ex.Message, ex);

        //    }
        //}




    }
}