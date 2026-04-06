using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarFondoLeyFovisCommand(int AnioMes) : IRequest;