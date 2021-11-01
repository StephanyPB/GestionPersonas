using GestionPersonas.DAL;
using GestionPersonas.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestionPersonas.BLL
{
    public class AportesBLL
    {
        public static bool Guardar(Aportes aporte)
        {
            if (!Existe(aporte.AporteId))
            {
                return Insertar(aporte);
            }
            else
            {
                return Modificar(aporte);
            }
        }
        private static bool Insertar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto

                foreach (var item in aporte.Detalle)
                {
                    TipoAportes tipoAporte = contexto.tipoAportes.Find(item.TipoAporteId);
                    tipoAporte.MontoLogrado += item.Monto;
                    ModificarTiposAportes(tipoAporte);
                }

                contexto.Aportes.Add(aporte);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }
        public static bool Modificar(Aportes aporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //BUSCAMOS EL DETALLE COMO ESTABA ANTES DE LA MODIFICACION PARA RESTARLE ESOS MONTOS AL TIPO DE APORTE
                var AporteAntes = contexto.Aportes.Where(x => x.AporteId == aporte.AporteId).Include(x=>x.Detalle).AsNoTracking().SingleOrDefault();

                foreach (var item in AporteAntes.Detalle)
                {
                    TipoAportes tipoAporte = contexto.tipoAportes.Find(item.TipoAporteId);
                    tipoAporte.MontoLogrado -= item.Monto;
                    ModificarTiposAportes(tipoAporte);
                }

                //VACIAMOS LA TABLA DEL DETALLE
                contexto.Database.ExecuteSqlRaw($"Delete FROM AportesDetalle Where AporteId={aporte.AporteId}");

                //SUMAMOS LOS NUEVOS MONTOS A LOS TIPOS DEL DETALLE QUE ESTAMOS MODIFICANDO
                foreach (var item in aporte.Detalle)
                {
                    item.Id = 0;
                    TipoAportes tipoAporte = contexto.tipoAportes.Find(item.TipoAporteId);
                    tipoAporte.MontoLogrado += item.Monto;
                    ModificarTiposAportes(tipoAporte);
                    contexto.Entry(item).State = EntityState.Added;
                }


                contexto.Entry(aporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var Aportes = Buscar(id);

                if (Aportes != null)
                {

                    foreach (var item in Aportes.Detalle)
                    {
                        TipoAportes tipoAporte = contexto.tipoAportes.Find(item.TipoAporteId);
                        tipoAporte.MontoLogrado -= item.Monto;
                        ModificarTiposAportes(tipoAporte);
                    }

                    contexto.Aportes.Remove(Aportes);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        public static Aportes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Aportes Aporte;

            try
            {
                Aporte = contexto.Aportes.Where(x=>x.AporteId==id).Include(x=>x.Detalle).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return Aporte;
        }
        public static List<Aportes> GetList(Expression<Func<Aportes, bool>> criterio)
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(r => r.AporteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static bool ExisteConcepto(string concepto)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Aportes.Any(r => r.Concepto == concepto);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        public static List<Aportes> GetRoles()
        {
            List<Aportes> lista = new List<Aportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Aportes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        public static List<TipoAportes> GetTiposAportes(Expression<Func<TipoAportes, bool>> criterio)
        {
            List<TipoAportes> lista = new List<TipoAportes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.tipoAportes.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }  

        public static bool ModificarTiposAportes(TipoAportes tipoAporte)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(tipoAporte).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
    }
}
