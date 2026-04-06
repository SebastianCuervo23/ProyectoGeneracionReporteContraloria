using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarFondoLeyFoninez2Command(int AnioMes) : IRequest;