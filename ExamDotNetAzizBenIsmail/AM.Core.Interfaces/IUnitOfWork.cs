using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Interfaces
{
    //IDisposable:permet de nettoyer l'espace reservé par l'espace memoire 
    //GarbageCollector:permet de nettoyer la memoire d'une maniere continue
    // 2Ressources
    //1-R managées:ynajem ynadhefhom wahdou aut :variable, instances
    //2-R nonManagées:meeynajemch ynadhefhom :BDD ,Fichier,Reseau

    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        void Save();
    }
}
