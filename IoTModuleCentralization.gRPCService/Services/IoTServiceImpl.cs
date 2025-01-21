using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using IoT_Module_Centralization.DataAccess.Repositories.Modules;
using IoT_Module_Centralization.Domain.ValueObjects;
using IoT_Module_Centralization.gRPCProtos;

public class IoTServiceImpl : IoTService.IoTServiceBase
{
    private readonly IModuleRepository _moduleRepository;

    public IoTServiceImpl(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public override Task<ModuleDTO> GetModuleById(ModuleIdRequest request, ServerCallContext context)
    {
        var module = _moduleRepository.GetById(Guid.Parse(request.Id));
        if (module == null) throw new RpcException(new Status(StatusCode.NotFound, "Módulo no encontrado"));

        return Task.FromResult(new ModuleDTO
        {
            Id = module.Id.ToString(),
            Name = module.Name,
            IpAddress = module.IpAddress.Value,
            Port = module.Port.Value,
            Status = module.Status
        });
    }

    public override Task<Empty> AddModule(ModuleDTO request, ServerCallContext context)
    {
        var module = new Module(Guid.NewGuid(), request.Name, new IpAddress(request.IpAddress), new Port(request.Port), request.Status);
        _moduleRepository.Add(module);

        return Task.FromResult(new Empty());
    }
}
