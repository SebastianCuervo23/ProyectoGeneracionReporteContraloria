using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarFondoLeyFoninezeCommand(int AnioMes) : IRequest;