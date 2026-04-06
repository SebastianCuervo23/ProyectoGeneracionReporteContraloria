using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarFondoLeyFosfecCommand(int AnioMes) : IRequest;