using MediatR;

namespace ExportadorTxt.Application.Commands
{
    public record GenerarAfiliadosCommand(int AnioMes) : IRequest;
}
