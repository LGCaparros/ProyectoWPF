using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas
{
    class Pelicula : INotifyPropertyChanged
    {
		public enum GenerosCine
		{
			Comedia,
			Drama,
			Accion,
			Terror,
			CienciaFiccion
		}

		public enum TipoDificultad
		{
			Facil,
			Normal,
			Dificil
		}

		private string _titulo;
		public string Titulo
		{
			get { return _titulo; }
			set 
			{
				_titulo = value;
				this.NotifyPropertyChanged("Titulo");
			}
		}

		private string _pista;
		public string Pista
		{
			get { return _pista; }
			set
			{
				_pista = value;
				this.NotifyPropertyChanged("Pista");
			}
		}

		private string _imagen;

		public string Imagen
		{
			get { return _imagen; }
			set
			{
				_imagen = value;
				this.NotifyPropertyChanged("Imagen");
			}
		}

		private TipoDificultad _dificultad;

		public TipoDificultad Dificultad
		{
			get { return _dificultad; }
			set
			{
				_dificultad = value;
				this.NotifyPropertyChanged("Dificultad");
			}
		}

		private GenerosCine _genero;

		public Pelicula()
		{
		}

		public Pelicula(string titulo, string pista, string imagen, TipoDificultad dificultad, GenerosCine genero)
		{
			Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
			Pista =  pista ?? throw new ArgumentNullException(nameof(pista));
			Imagen = imagen ?? throw new ArgumentNullException(nameof(imagen));
			Dificultad = dificultad;
			Genero = genero;
		}

		public GenerosCine Genero
		{
			get { return _genero; }
			set
			{
				_genero = value;
				this.NotifyPropertyChanged("Genero");
			}
		}

		public void NotifyPropertyChanged(string propertyName)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
    }
}
