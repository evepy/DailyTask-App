using System;
using System.Collections.Generic;
using System.Text;
using DailyTask.Models;
using SQLite;

namespace DailyTask.Data
{
    public class dbsqlite
    {
        string dbruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        //CRUD TAREAS
        public bool conectdb()
        {
            try
            {
                using (var cox = new SQLiteConnection(System.IO.Path.Combine(dbruta, "tarea.db")))
                {
                    cox.CreateTable<TareaModel>();
                    return true;
                }
            }
            catch (SQLiteException)
            {
                //Log.Info("No SQLite", ex.Message);
                return false;
            }
        }
        public bool Agregar(TareaModel tareaModel)
        {
            try
            {
                using (var cox = new SQLiteConnection(System.IO.Path.Combine(dbruta, "tarea.db")))
                {
                    cox.Insert(tareaModel);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                //Log.Info("No se inserto la tarea", ex.Message);
                return false;
            }
        }
        public List<TareaModel> GetTareaModels()
        {

            try
            {
                using (var cox = new SQLiteConnection(System.IO.Path.Combine(dbruta, "tarea.db")))
                {
                    return cox.Table<TareaModel>().ToList();
                }
            }
            catch (SQLiteException)
            {
                //Log.Info("No se pueden ver las tareas", ex.Message);
                return null;
            }
        }
        public TareaModel GetTareaUnica(int id)
        {
            using(var cox = new SQLiteConnection(System.IO.Path.Combine(dbruta, "tarea.db")))
            {
                TareaModel TU = (from mem in cox.Table<TareaModel>() where mem.ID== id select mem).FirstOrDefault();
                return TU;
            }
        }
        public bool Actualizar(TareaModel tareaModel)
        {
            try
            {
                using (var cox = new SQLiteConnection(System.IO.Path.Combine(dbruta, "tarea.db")))
                {
                    cox.Query<TareaModel>("UPDATE TareaModel set NombreTarea=?, Categoria=?, Descripcion=?, Fecha=? Where ID=?", tareaModel.NombreTarea, tareaModel.Categoria, tareaModel.Descripcion, tareaModel.Fecha, tareaModel.ID);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                //Log.Info("No se actualizo la tarea", ex.Message);
                return false;
            }
        }
        public bool Eliminar(TareaModel tareaModel)
        {
            try
            {
                using (var cox = new SQLiteConnection(System.IO.Path.Combine(dbruta, "tarea.db")))
                {
                    cox.Delete(tareaModel);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                //Log.Info("No se elimino la tarea", ex.Message);
                return false;
            }
        }
    }
}
