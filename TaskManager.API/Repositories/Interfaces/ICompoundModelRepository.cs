namespace TaskManager.API.Repositories.Interfaces
{

    public interface ICompoundModelRepository<Model, Domain, Identity, CompoundIdentity>
    {
        public Task<Model> Create(Domain domain, CompoundIdentity compoundEntityId);
        public Task<List<Model>> Read();
        public Task<Model?> ReadById(Identity id);
        public Task<Model> Update(Identity id, Domain domain);
        public Task<Model> Delete(Identity id);
    }
}

