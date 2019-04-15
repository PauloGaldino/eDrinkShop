using System.Collections.Generic;
using Application.Interfaces.IAppContatos;
using Domain.Entities.Contatos;
using Domain.Interfaces.IContatos;

namespace Application.Aplications.AppContatos
{
    public class AppTeleFoneTipo : IAppTelefoneTipo
    {
        ITelefoneTipo _ITelefoneTipo;
        public AppTeleFoneTipo(ITelefoneTipo ITelefoneTipo)
        {
            _ITelefoneTipo = ITelefoneTipo;
        }

        public void Adcionar(TelefoneTipo Objeto)
        {
            _ITelefoneTipo.Adcionar(Objeto);
        }

        public void Atualizar(TelefoneTipo Objeto)
        {
            _ITelefoneTipo.Atualizar(Objeto);
        }

        public void Excluir(TelefoneTipo Objeto)
        {
            _ITelefoneTipo.Excluir(Objeto);
        }

        public IList<TelefoneTipo> Listar()
        {
            return _ITelefoneTipo.Listar();
        }

        public TelefoneTipo ObterPorId(int Id)
        {
            return _ITelefoneTipo.ObterPorId(Id);
        }
    }
}
