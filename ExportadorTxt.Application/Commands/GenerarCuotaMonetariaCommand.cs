using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarCuotaMonetariaCommand(int AnioMes) : IRequest;