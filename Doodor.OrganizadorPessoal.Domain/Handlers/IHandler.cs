using Doodor.OrganizadorPessoal.Domain.Events;


namespace Doodor.OrganizadorPessoal.Domain.Handlers
{
    //IHandler<in T> o in T é uma contra variança que indica que ao passar T, 
    //T pode ser uma Message ou um descendente não direto de Message
    public interface IHandler<in T> where T: Message
    {
        void Handle(T message);
    }
}
