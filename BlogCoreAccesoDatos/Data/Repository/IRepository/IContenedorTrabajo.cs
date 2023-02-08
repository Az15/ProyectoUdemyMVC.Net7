using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        //Aca se agregan los repositorios. Para trabajar mas organizado y no andar copiando codigo constantemente.(Encapsulamiento y Rapido Testing)
            ICategoriaRepository Categoria { get; }
            IArticuloRepository Articulo { get; }
            ISliderRepository Slider { get; }

            IusuarioRepository Usuario { get; }

        void Save();

    }
}
