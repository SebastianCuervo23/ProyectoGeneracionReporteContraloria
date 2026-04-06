using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarFondoLey115Command(int AnioMes) : IRequest;