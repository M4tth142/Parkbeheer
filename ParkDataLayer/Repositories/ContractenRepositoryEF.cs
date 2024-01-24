using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ParkDataLayer.Repositories
{
    /// <summary>
    /// Represents a repository for managing contracts using Entity Framework.
    /// </summary>
    public class ContractenRepositoryEF : IContractenRepository
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractenRepositoryEF"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for the database.</param>
        public ContractenRepositoryEF(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Cancels a contract in the database.
        /// </summary>
        /// <param name="contract">The contract entity to be canceled.</param>
        public void AnnuleerContract(HuurcontractEntity contract)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var existingContract = context.Huurcontracten.FirstOrDefault(c => c.Id == contract.Id);
                    if (existingContract == null)
                    {
                        throw new RepositoryException($"Contract with ID {contract.Id} not found in the database.");
                    }

                    context.Huurcontracten.Remove(existingContract);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("AnnuleerContract: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Retrieves a contract entity from the database based on the specified ID.
        /// </summary>
        /// <param name="id">The ID of the contract to retrieve.</param>
        /// <returns>The contract entity.</returns>
        public HuurcontractEntity GeefContract(string id)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var contract = context.Huurcontracten
                                          .Where(c => c.Id == id)
                                          .Select(HuurcontractMapper.MapToHuurcontractEntity)
                                          .SingleOrDefault();
                    if (contract == null)
                    {
                        throw new RepositoryException($"Contract with ID {id} not found in the database.", nameof(id));
                    }
                    return contract;
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("GeefContract: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Retrieves a list of contract entities that fall within the specified date range.
        /// </summary>
        /// <param name="dtBegin">The start date of the range.</param>
        /// <param name="dtEinde">The end date of the range (nullable).</param>
        /// <returns>A list of contract entities.</returns>
        public List<HuurcontractEntity> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var contracts = context.Huurcontracten
                        .Where(contract => contract.StartDatum >= dtBegin)
                        .Where(contract => dtEinde == null || contract.EindDatum <= dtEinde)
                        .ToList();
                    var contractsEntities = contracts.Select(HuurcontractMapper.MapToHuurcontractEntity).ToList();
                    return contractsEntities;
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("GeefContracten: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Checks if a contract exists for the specified start date, renter ID, and house ID.
        /// </summary>
        /// <param name="startDatum">The start date of the contract.</param>
        /// <param name="huurderid">The ID of the renter.</param>
        /// <param name="huisid">The ID of the house.</param>
        /// <returns>True if a contract exists; otherwise, false.</returns>
        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a contract with the specified ID exists in the database.
        /// </summary>
        /// <param name="id">The ID of the contract to check.</param>
        /// <returns>True if a contract exists; otherwise, false.</returns>
        public bool HeeftContract(string id)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    return context.Huurcontracten.Any(c => c.Id == id);
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("HeeftContract: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Updates an existing contract in the database.
        /// </summary>
        /// <param name="con">The updated contract entity.</param>
        public void UpdateContract(HuurcontractEntity con)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    var existingContract = context.Huurcontracten.SingleOrDefault(c => c.Id == con.Id);
                    var contract = HuurcontractMapper.MapToHuurcontract(con);

                    if (existingContract == null)
                    {
                        throw new RepositoryException($"Contract with ID {contract.Id} not found in the database.");
                    }

                    // Update the properties of the existing contract with the new values
                    existingContract.StartDatum = contract.StartDatum;
                    existingContract.EindDatum = contract.EindDatum;
                    existingContract.AantalDagen = contract.AantalDagen;
                    existingContract.HuisId = contract.HuisId;
                    existingContract.HuurderId = contract.HuurderId;

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("UpdateContract: " + ex.Message, ex);
                }
            }
        }

        /// <summary>
        /// Adds a new contract to the database.
        /// </summary>
        /// <param name="contract">The contract entity to be added.</param>
        public void VoegContractToe(HuurcontractEntity contract)
        {
            using (var context = new ParkDbContext())
            {
                try
                {
                    context.Huurcontracten.Add(HuurcontractMapper.MapToHuurcontract(contract));
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new RepositoryException("VoegContractToe: " + ex.Message, ex);
                }
            }
        }
    }

}
