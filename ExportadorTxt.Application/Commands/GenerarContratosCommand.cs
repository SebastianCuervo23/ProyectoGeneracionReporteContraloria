using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarContratosCommand(int AnioMes) : IRequest;