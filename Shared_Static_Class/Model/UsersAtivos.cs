using Newtonsoft.Json;
using System.ComponentModel;

namespace Shared_Razor_Components.FundamentalModels
{
    public class UsersAtivos : INotifyPropertyChanged
    {
        private List<AcessoModel> usuariosAtivos { get; set; } = new();

        public List<AcessoModel> UsuariosAtivos
        {
            get => usuariosAtivos;
            set
            {
                usuariosAtivos = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UsuariosAtivos)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
