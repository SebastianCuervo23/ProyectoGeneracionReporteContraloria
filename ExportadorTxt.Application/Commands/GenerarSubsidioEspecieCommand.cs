using MediatR;

namespace ExportadorTxt.Application.Commands;

public record GenerarSubsidioEspecieCommand(int AnioMes) : IRequest;