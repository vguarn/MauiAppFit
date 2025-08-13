﻿using System;
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


    }
}
