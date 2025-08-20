using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppFit;
using Systen.ComponentModel;
using System.Windows.Input;

namespace MauiAppFit.ViewsModels
{
    [QueryProperty("PegarIdDaNavegacao", "parametro_id")]

    public class CadastroAtividadeViewModel : INotifyPropertChanged
    {
        public event PropertyChangeEventHandler PropertyChanged;

        string descricao, observacoes;
        int id;
        DateTime data;
        double? peso;


        public string PegarIdDaNavegacao
        {
            set
            {
                int id_parametro = Convert.ToInt32(
                    Uri.UnescapeDataString(value));
                    
                VerAtividade.execute(id_paranetro)
            }
        }

        public string Descricao
        {
            get => descricao;
            set
            {
                descricao = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs ("Descricao"));
            }
        }

        public string Observacoes
        {
            get => observacoes;
            set
            {
                observacoes = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Observacoes"));
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Id"));
            }
        }

        public DateTime Data
        {
            get => data;
            set
            {
                data = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Data"));
            }
        }

        public double? Peso
        {
            get => peso;
            set
            {
                peso = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Peso"));
            }
        }

        public ICommand NovaAtividade
        {
            get => new ICommand(() =>
            {
                id = 0;
                Descricao = string.Empty;
                Data = DateTime.Now;
                Peso = null;
                Observacao = string.Empty;
            });
        }



        public ICommand SalvarAtividade
        {
            get => new Command(async () =>
            {
                try
                {
                    CadastroAtividadeViewModel model = new()
                    {
                        Descricao = this.Descricao,
                        Data = this.Data,
                        Peso = this.Peso,
                        Observacoes = this.Observacao
                    };

                    if (this.Id == 0)
                    {
                        await App.Database.Insert(model);
                    }
                    else
                    {
                        model.Id = this.Id;
                        await MauiAppFit.Database.Update(model);
                    }

                    await Shell.Current.DisplayAlert("Beleza",
                            "Atividade salva!", "OK");

                    await Shell.Current.GoToAsync("//MinhaAtividades");
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Ops",
                            ex.Message, "OK");
                }
            }
            
        });

        public ICommand VerAtividade
        {
            get => new Command<int>(async(int id) =>
            {
                try
                {
                    Atividade model = await MauiAppFit.Database.GetById(id);

                    this.Id = model.Id;
                    this.Descricao = model.Descricao;
                    this.Peso = model.Peso;
                    this.Data = model.Data;
                    this.Observacoes = model.Observacoes;
                }
                catch (Exception ex)
                {
                    await Shell.Current.DisplayAlert("Ops", ex.Message, "OK");
                }
            }
                
        });


    }
}
