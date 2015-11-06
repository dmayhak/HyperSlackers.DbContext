﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HyperSlackers.AspNet.Identity.EntityFramework.ExtensionMethods;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Reflection;

namespace HyperSlackers.AspNet.Identity.EntityFramework.Core
{
    /// <summary>
    /// Manages automatic auditing/logging of changes to entities stored in the database.
    /// </summary>
    /// <typeparam name="THost">The type of the host.</typeparam>
    /// <typeparam name="THostDomain">The type of the host domain.</typeparam>
    /// <typeparam name="TUser">The type of the user.</typeparam>
    /// <typeparam name="TRole">The type of the role.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TUserLogin">The type of the user login.</typeparam>
    /// <typeparam name="TUserRole">The type of the user role.</typeparam>
    /// <typeparam name="TUserClaim">The type of the user claim.</typeparam>
    /// <typeparam name="TAudit">The type of the audit.</typeparam>
    /// <typeparam name="TAuditItem">The type of the audit item.</typeparam>
    /// <typeparam name="TAuditProperty">The type of the audit property.</typeparam>
    public class HyperDbContextAuditing<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty> : HyperDbContextBase<THost, THostDomain, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TGroup, TGroupRole, TGroupUser, TAudit, TAuditItem, TAuditProperty>
        where THost : HyperHost<TKey, THost, THostDomain>, new()
        where THostDomain : HyperHostDomain<TKey, THost, THostDomain>, new()
        where TUser : HyperUser<TKey, TUserLogin, TUserRole, TUserClaim, TGroupUser>, IHyperUser<TKey>, new()
        where TRole : HyperRole<TKey, TUserRole>, IHyperRole<TKey>, new()
        where TKey : struct, IEquatable<TKey>
        where TUserLogin : HyperUserLogin<TKey>, IHyperUserLogin<TKey>, new()
        where TUserRole : HyperUserRole<TKey>, IHyperUserRole<TKey>, new()
        where TUserClaim : HyperUserClaim<TKey>, IHyperUserClaim<TKey>, new()
        where TGroup : HyperGroup<TKey, TGroupRole, TGroupUser>, new()
        where TGroupRole : HyperGroupRole<TKey>, new()
        where TGroupUser : HyperGroupUser<TKey>, new()
        where TAudit : HyperAudit<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditItem : HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty>, new()
        where TAuditProperty : HyperAuditProperty<TKey, TAudit, TAuditItem, TAuditProperty>, new()
    {
        //! table/schema renaming
        protected internal string AuditSchemaName;                  // the schema name to user for the auditing tables
        protected internal string AuditsTableName;                  // name to use for the audits table
        protected internal string AuditItemsTableName;              // name to use for the audit items table
        protected internal string AuditPropertiesTableName;         // name to use for the audit properties table

        /// <summary>
        /// Gets or sets a value indicating whether audit records will be created or not.
        /// In either case, the LastChanged Date/User fields will be updated.
        /// </summary>
        /// <value>
        ///   <c>true</c> if auditing is enabled; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AuditingEnabled { get; set; }

        //! audit creation
        private DateTime auditDate;
        private TAudit currentAudit;
        private List<TAuditItem> currentAuditItems;
        private List<TAuditProperty> currentAuditProperties;

        //! audit dbsets
        public DbSet<TAudit> Audits { get; set; }
        public DbSet<TAuditItem> AuditItems { get; set; }
        public DbSet<TAuditProperty> AuditProperties { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="HyperDbContextAuditing{THost, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TAudit, TAuditItem, TAuditProperty}" /> class.
        /// </summary>
        protected HyperDbContextAuditing()
            : this("DefaultConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HyperDbContextAuditing{THost, TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim, TAudit, TAuditItem, TAuditProperty}" /> class.
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        protected HyperDbContextAuditing(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Contract.Requires<ArgumentNullException>(!nameOrConnectionString.IsNullOrWhiteSpace(), "nameOrConnectionString");

            this.AuditSchemaName = string.Empty;
            this.AuditsTableName = string.Empty;
            this.AuditItemsTableName = string.Empty;
            this.AuditPropertiesTableName = string.Empty;

            this.AuditingEnabled = true;
        }

        /// <summary>
        /// Maps table names, and sets up relationships between the various user entities.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fix up table names, indexes, and identity columns (Guid Id columns are not db-assigned)
            modelBuilder.Entity<TAudit>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TAuditItem>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<TAuditProperty>()
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption((typeof(TKey) == typeof(Guid) || typeof(TKey) == typeof(string)) ? DatabaseGeneratedOption.None : DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<TAudit>()
                .ToTable((AuditsTableName.IsNullOrWhiteSpace() ? "AspNetAudits" : AuditsTableName), (AuditSchemaName.IsNullOrWhiteSpace() ? "dbo" : AuditSchemaName));

            modelBuilder.Entity<TAuditItem>()
                 .ToTable((AuditItemsTableName.IsNullOrWhiteSpace() ? "AspNetAuditItems" : AuditItemsTableName), (AuditSchemaName.IsNullOrWhiteSpace() ? "dbo" : AuditSchemaName));

            modelBuilder.Entity<TAuditProperty>()
                 .ToTable((AuditPropertiesTableName.IsNullOrWhiteSpace() ? "AspNetAuditProperties" : AuditPropertiesTableName), (AuditSchemaName.IsNullOrWhiteSpace() ? "dbo" : AuditSchemaName));
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        public override int SaveChanges()
        {
            // set this on each call so that multiple call to save changes each get a new time
            this.auditDate = DateTime.Now;

            ChangeTracker.DetectChanges(); //! important to call this prior to auditing, etc.

            UpdateAuditUserAndDateFields(); // last changed date/by, created date/by, etc...

            // short-circuit if disabled
            if (!AuditingEnabled)
            {
                return base.SaveChanges();
            }

            CreateAuditRecords(); // create audit data and hold it until after we save user's changes

            // save changes
            int rowCount = base.SaveChanges(); // save the change count so our audit stuff does not affect the return value...

            // put audit records into DbContext and save them
            AppendAuditRecordsToContext(); //! this calls base.SaveChanges()! (if audit records exist)

            return rowCount;
        }

        /// <summary>
        /// Gets the entity edit points.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public HyperEntityEditPoint<TKey>[] GetEntityEditPoints(IAuditable<TKey> entity)
        {
            var auditIds = this.AuditItems
                .Where(i => i.Entity1Id.Equals(entity.Id))
                .Select(i => i.AuditId)
                .Distinct()
                .ToArray();

            return this.Audits
                .Where(a => auditIds.Contains(a.Id))
                .Select(a => new HyperEntityEditPoint<TKey>() { EntityId = entity.Id, EditDate = a.AuditDate, UserName = a.UserName, UserId = a.UserId })
                .OrderByDescending(ep => ep.EditDate)
                .ToArray();
        }

        /// <summary>
        /// Gets the entity versions.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public HyperEntityVersion<TKey, TEntity>[] GetEntityVersions<TEntity>(TEntity entity)
            where TEntity : IAuditable<TKey>
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");

            var versions = new List<HyperEntityVersion<TKey, TEntity>>();

            var auditIds = this.AuditItems
                .Where(i => i.Entity1Id.Equals(entity.Id))
                .Select(i => i.AuditId)
                .Distinct()
                .ToArray();

            var audits = this.Audits
                .Where(a => auditIds.Contains(a.Id))
                .OrderByDescending(a => a.AuditDate)
                .ToArray();

            TEntity lastVersion = entity;
            foreach (var audit in audits)
            {
                TEntity currentVersion = lastVersion.Copy();

                Contract.Assume(currentVersion != null);

                var auditItems = this.AuditItems
                    .Where(i => i.AuditId.Equals(audit.Id) && i.Entity1Id.Equals(entity.Id));

                // set properties back to pre-edit versions
                foreach (var auditItem in auditItems)
                {
                    SetEntityProperty(currentVersion, auditItem);
                }

                versions.Add(new HyperEntityVersion<TKey, TEntity>() { EditDate = audit.AuditDate, UserName = audit.UserName, UserId = audit.UserId, Entity = currentVersion });

                lastVersion = currentVersion;
            }


            return versions.ToArray();
        }

        /// <summary>
        /// Gets the entity property versions.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public HyperEntityPropertyVersion<TKey>[] GetEntityPropertyVersions<TEntity>(TEntity entity, string propertyName)
            where TEntity : IAuditable<TKey>
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
            Contract.Requires<ArgumentNullException>(!propertyName.IsNullOrWhiteSpace(), "propertyName");

            var versions = new List<HyperEntityPropertyVersion<TKey>>();

            var auditIds = this.AuditItems
                .Where(i => i.Entity1Id.Equals(entity.Id))
                .Select(i => i.AuditId)
                .Distinct()
                .ToArray();

            var audits = this.Audits
                .Where(a => auditIds.Contains(a.Id))
                .OrderByDescending(a => a.AuditDate)
                .ToArray();

            var auditProperty = GetAuditProperty(entity, propertyName);
            if (auditProperty == null)
            {
                // property not logged, or does not exist
                return versions.ToArray();
            }

            foreach (var audit in audits)
            {
                var auditItems = this.AuditItems
                    .Where(i => i.AuditId.Equals(audit.Id) && i.Entity1Id.Equals(entity.Id) && i.AuditPropertyId.Equals(auditProperty.Id));

                // set properties back to pre-edit versions
                foreach (var auditItem in auditItems)
                {
                    versions.Add(new HyperEntityPropertyVersion<TKey>() { EditDate = audit.AuditDate, UserName = audit.UserName, UserId = audit.UserId, PropertyName = propertyName, PropertyValue = auditItem.NewValue });
                }
            }


            return versions.ToArray();
        }

        /// <summary>
        /// Sets the entity property.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="auditItem">The audit item.</param>
        private void SetEntityProperty(IAuditable<TKey> entity, HyperAuditItem<TKey, TAudit, TAuditItem, TAuditProperty> auditItem)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
            Contract.Requires<ArgumentNullException>(auditItem != null, "auditItem");

            var auditProperty = this.AuditProperties.Single(p => p.Id.Equals(auditItem.AuditPropertyId));

            PropertyInfo prop = GetEntityType(entity).GetProperty(auditProperty.PropertyName);

            if (auditItem.NewValue == null)
            {
                prop.SetValue(entity, null);
            }
            else
            {
                var type = prop.PropertyType;
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    type = Nullable.GetUnderlyingType(type);
                }

                prop.SetValue(entity, Convert.ChangeType(auditItem.NewValue, type));
            }
        }

        /// <summary>
        /// Updates the audit fields (CreatedDate, CreatedBy, LastChangedDate, and LastChangedBy).
        /// </summary>
        private void UpdateAuditUserAndDateFields()
        {
            // set created and last changed fields for added entities
            var addedEntities = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Added).Where(ose => !ose.IsRelationship);
            //var addedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var item in addedEntities)
            {
                IAuditableUserAndDate<TKey> entity = item.Entity as IAuditableUserAndDate<TKey>;
                if (entity != null)
                {
                    entity.CreatedDate = this.auditDate;
                    entity.CreatedBy = this.UserId;
                    entity.LastChangedDate = this.auditDate;
                    entity.LastChangedBy = this.UserId;
                }
            }

            // set last changed fields for updated entities
            var changedEntities = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Modified).Where(ose => !ose.IsRelationship);
            //var changedEntities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                IAuditableUserAndDate<TKey> entity = item.Entity as IAuditableUserAndDate<TKey>;
                if (entity != null)
                {
                    entity.LastChangedDate = this.auditDate;
                    entity.LastChangedBy = this.UserId;
                }
            }
        }

        /// <summary>
        /// Creates the audit records.
        /// </summary>
        private void CreateAuditRecords()
        {
            this.currentAudit = new TAudit() { AuditDate = this.auditDate, HostId = this.HostId, HostName = this.HostName, UserId = this.UserId, UserName = this.UserName };
            this.currentAuditProperties = new List<TAuditProperty>();
            this.currentAuditItems = new List<TAuditItem>();

            CreateAuditInsertRecords();
            CreateAuditUpdateRecords();
            CreateAuditDeleteRecords();
            CreateAuditAddRelationRecords();
            CreateAuditDeleteRelationRecords();
        }

        /// <summary>
        /// Appends the audit records to context.
        /// </summary>
        private void AppendAuditRecordsToContext()
        {
            if (this.currentAuditItems == null || this.currentAuditItems.Count == 0)
            {
                // nothing audited, no need to add the audit record to the database
                return;
            }

            var autoDetect = this.Configuration.AutoDetectChangesEnabled;
            try
            {
                this.Configuration.AutoDetectChangesEnabled = false;

                this.Audits.Add(this.currentAudit);

                foreach (var item in this.currentAuditProperties)
                {
                    if (item.Id.Equals(default(TKey)))
                    {
                        this.AuditProperties.Add(item);
                    }
                }

                // need to save changes to get audit and audit property ids
                base.SaveChanges();

                foreach (var item in this.currentAuditItems)
                {
                    // get ids parents (some might have been new)
                    item.AuditId = item.Audit.Id;
                    item.AuditPropertyId = item.AuditProperty.Id;

                    // get entity ids
                    if (item.Entity1 != null)
                    {
                        item.Entity1Id = item.Entity1.Id;
                    }
                    if (item.Entity2 != null)
                    {
                        item.Entity2Id = item.Entity2.Id;
                    }

                    this.AuditItems.Add(item);
                }

                base.SaveChanges();
            }
            finally
            {
                this.Configuration.AutoDetectChangesEnabled = autoDetect;
            }
        }

        /// <summary>
        /// Creates the audit insert records.
        /// </summary>
        private void CreateAuditInsertRecords()
        {
            var entities = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Added).Where(ose => !ose.IsRelationship);
            //var entities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var item in entities)
            {
                IAuditable<TKey> entity = item.Entity as IAuditable<TKey>;
                if (entity != null)
                {
                    try
                    {
                        string oldValue = null;
                        string newValue;

                        var props = GetEntityType(entity).GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        foreach (var prop in props)
                        {
                            TAuditProperty auditProperty = GetAuditProperty(entity, prop);

                            if (auditProperty != null)
                            {
                                var newObj = prop.GetValue(entity);

                                newValue = newObj == null || newObj == DBNull.Value ? null : newObj.ToString();

                                if (newValue != oldValue)
                                {
                                    TAuditItem auditItem = new TAuditItem() { Audit = this.currentAudit, AuditProperty = auditProperty, Entity1 = entity, Entity2 = null, OperationType = "C", OldValue = oldValue, NewValue = newValue };

                                    this.currentAuditItems.Add(auditItem);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: log the error?
                        System.Diagnostics.Debug.WriteLine("Error auditing an insert: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Creates the audit update records.
        /// </summary>
        private void CreateAuditUpdateRecords()
        {
            var entities = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Modified).Where(ose => !ose.IsRelationship);
            //var entities = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            foreach (var item in entities)
            {
                IAuditable<TKey> entity = item.Entity as IAuditable<TKey>;
                if (entity != null)
                {
                    try
                    {
                        string oldValue;
                        string newValue;

                        var props = GetEntityType(entity).GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        foreach (var prop in props)
                        {
                            TAuditProperty auditProperty = GetAuditProperty(entity, prop);

                            if (auditProperty != null)
                            {
                                var oldObj = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity).OriginalValues[prop.Name];
                                var newObj = prop.GetValue(entity);

                                oldValue = oldObj == null || oldObj == DBNull.Value ? null : oldObj.ToString();
                                newValue = newObj == null || newObj == DBNull.Value ? null : newObj.ToString();

                                if (newValue != oldValue)
                                {
                                    TAuditItem auditItem = new TAuditItem() { Audit = this.currentAudit, AuditProperty = auditProperty, Entity1 = entity, Entity2 = null, OperationType = "U", OldValue = oldValue, NewValue = newValue };

                                    this.currentAuditItems.Add(auditItem);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: log the error?
                        System.Diagnostics.Debug.WriteLine("Error auditing an update: " + ex.Message);
                    }

                }
            }
        }

        /// <summary>
        /// Creates the audit delete records.
        /// </summary>
        private void CreateAuditDeleteRecords()
        {
            // audit deleted items
            var entities = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Deleted).Where(ose => !ose.IsRelationship);
            //var entities = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
            foreach (var item in entities)
            {
                IAuditable<TKey> entity = item.Entity as IAuditable<TKey>;
                if (entity != null)
                {
                    try
                    {
                        string oldValue;
                        string newValue;

                        var props = GetEntityType(entity).GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        foreach (var prop in props)
                        {
                            TAuditProperty auditProperty = GetAuditProperty(entity, prop);

                            if (auditProperty != null)
                            {
                                var oldObj = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity).OriginalValues[prop.Name];
                                var newObj = prop.GetValue(entity);

                                oldValue = oldObj == null || oldObj == DBNull.Value ? null : oldObj.ToString();
                                newValue = newObj == null || newObj == DBNull.Value ? null : newObj.ToString();

                                if (newValue != oldValue)
                                {
                                    TAuditItem auditItem = new TAuditItem() { Audit = this.currentAudit, AuditProperty = auditProperty, Entity1 = entity, Entity2 = null, OperationType = "D", OldValue = oldValue, NewValue = newValue };

                                    this.currentAuditItems.Add(auditItem);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: log the error?
                        System.Diagnostics.Debug.WriteLine("Error auditing a delete: " + ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Creates the audit add relation records.
        /// </summary>
        private void CreateAuditAddRelationRecords()
        {
            var relations = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Added).Where(ose => ose.IsRelationship);
            foreach (var item in relations)
            {
                try
                {
                    ObjectStateEntry parentEntry = GetEntityEntryFromRelation(item, 0);
                    ObjectStateEntry childEntry;
                    IAuditable<TKey> parent = parentEntry.Entity as IAuditable<TKey>;
                    if (parent != null)
                    {
                        IAuditable<TKey> child;

                        // Find representation of the relation
                        System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd relatedEnd = parentEntry.RelationshipManager.GetAllRelatedEnds().First(r => r.RelationshipSet == item.EntitySet);

                        childEntry = GetEntityEntryFromRelation(item, 1);
                        child = childEntry.Entity as IAuditable<TKey>;

                        if (child != null)
                        {
                            try
                            {
                                TAuditProperty auditProperty = GetAuditProperty(relatedEnd);
                                TAuditItem auditItem = new TAuditItem() { Audit = this.currentAudit, AuditProperty = auditProperty, Entity1 = parent, Entity2 = child, OperationType = "+", OldValue = string.Empty, NewValue = string.Empty };

                                this.currentAuditItems.Add(auditItem);
                            }
                            catch (Exception ex)
                            {
                                // TODO: log the error?
                                System.Diagnostics.Debug.WriteLine("Error auditing an add relation: " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error auditing added relation: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Creates the audit delete relation records.
        /// </summary>
        private void CreateAuditDeleteRelationRecords()
        {
            // audit deleted relationships
            var deletedRelations = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Deleted).Where(ose => ose.IsRelationship);
            foreach (var item in deletedRelations)
            {
                try
                {
                    ObjectStateEntry parentEntry = GetEntityEntryFromRelation(item, 0);
                    ObjectStateEntry childEntry;
                    IAuditable<TKey> parent = parentEntry.Entity as IAuditable<TKey>;
                    if (parent != null)
                    {
                        IAuditable<TKey> child;

                        // Find representation of the relation
                        System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd relatedEnd = parentEntry.RelationshipManager.GetAllRelatedEnds().First(r => r.RelationshipSet == item.EntitySet);

                        childEntry = GetEntityEntryFromRelation(item, 1);
                        child = childEntry.Entity as IAuditable<TKey>;

                        if (child != null)
                        {
                            try
                            {
                                TAuditProperty auditProperty = GetAuditProperty(relatedEnd);
                                TAuditItem auditItem = new TAuditItem() { Audit = this.currentAudit, AuditProperty = auditProperty, Entity1 = parent, Entity2 = child, OperationType = "-", OldValue = string.Empty, NewValue = string.Empty };

                                this.currentAuditItems.Add(auditItem);
                            }
                            catch (Exception ex)
                            {
                                // TODO: log the error?
                                System.Diagnostics.Debug.WriteLine("Error auditing a delete relation: " + ex.Message);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error auditing remove relation: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Gets the type of the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        private static Type GetEntityType(IEntity<TKey> entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
            Contract.Ensures(Contract.Result<Type>() != null);

            Type type = entity.GetType();

            if (type.FullName.StartsWith("System.Data.Entity.DynamicProxies."))
            {
                // we don't want the dynamic proxy, we want the actual class the proxy is based on
                return type.BaseType;

            }

            return type;
        }

        /// <summary>
        /// Gets the name of the entity type.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        private static string GetEntityTypeName(IEntity<TKey> entity)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
            Contract.Ensures(Contract.Result<string>() != null);

            Type type = GetEntityType(entity);

            return type.Name;
        }

        /// <summary>
        /// Gets the audit property.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="prop">The property.</param>
        /// <returns></returns>
        private TAuditProperty GetAuditProperty(IAuditable<TKey> entity, PropertyInfo prop)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
            Contract.Requires<ArgumentNullException>(prop != null, "prop");
            //x Contract.Ensures(Contract.Result<AuditProperty>() != null);

            string entityName = GetEntityTypeName(entity); // ObjectContext.GetObjectType(entity.GetType()).Name;
            string propertyName = prop.Name;

            // only value types are audited (include strings in this...)
            if (!prop.PropertyType.IsValueType && prop.PropertyType != typeof(string))
            {
                return null;
            }
            // do not log collections
            if (prop.PropertyType is IEnumerable)
            {
                return null;
            }
            // ignore properties with the ignore attribute
            if (prop.GetCustomAttributes(typeof(AuditIgnoreAttribute), true).FirstOrDefault() != null)
            {
                return null;
            }
            // ignore properties with the not tracked attribute
            if (prop.GetCustomAttributes(typeof(NotMappedAttribute), true).FirstOrDefault() != null)
            {
                return null;
            }

            // fix up the property type (not sure everyone will like this...
            string propertyType = prop.PropertyType.ToString();
            bool nullable = false;
            if (propertyType.StartsWith("System.Nullable"))
            {
                nullable = true;
                propertyType = propertyType.Substring(propertyType.IndexOf("[") + 1).TrimEnd(']');
            }
            if (propertyType.StartsWith("System."))
            {
                propertyType = propertyType.Substring(7);
            }
            if (propertyType == "String") { propertyType = "string"; }
            if (propertyType == "Int32") { propertyType = "int"; }
            if (propertyType == "Int64") { propertyType = "long"; }
            if (propertyType == "Int16") { propertyType = "short"; }
            if (propertyType == "Boolean") { propertyType = "bool"; }
            if (propertyType == "Byte") { propertyType = "byte"; }
            if (propertyType == "Single") { propertyType = "float"; }
            if (propertyType == "Double") { propertyType = "double"; }
            if (propertyType == "Decimal") { propertyType = "decimal"; }
            if (propertyType == "Char") { propertyType = "char"; }
            if (propertyType == "Sbyte") { propertyType = "sbyte"; }

            if (nullable)
            {
                propertyType += "?";
            }

            // check our list
            TAuditProperty auditProperty = this.currentAuditProperties.FirstOrDefault(ap => ap.EntityName == entityName && ap.PropertyName == propertyName && ap.IsRelation == false);

            if (auditProperty == null)
            {
                // check the database
                auditProperty = this.AuditProperties.FirstOrDefault(ap => ap.EntityName == entityName && ap.PropertyName == propertyName && ap.IsRelation == false);

                if (auditProperty == null)
                {
                    // create it
                    auditProperty = new TAuditProperty() { EntityName = entityName, PropertyName = propertyName, PropertyType = propertyType.ToString(), IsRelation = false };
                }

                this.currentAuditProperties.Add(auditProperty);
            }

            return auditProperty;
        }

        /// <summary>
        /// Gets the audit property.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        private TAuditProperty GetAuditProperty(IAuditable<TKey> entity, string propertyName)
        {
            Contract.Requires<ArgumentNullException>(entity != null, "entity");
            Contract.Requires<ArgumentNullException>(!propertyName.IsNullOrWhiteSpace(), "propertyName");
            //x Contract.Ensures(Contract.Result<AuditProperty>() != null);

            string entityName = GetEntityTypeName(entity); // ObjectContext.GetObjectType(entity.GetType()).Name;

            // check our list
            TAuditProperty auditProperty = this.currentAuditProperties.FirstOrDefault(ap => ap.EntityName == entityName && ap.PropertyName == propertyName);

            if (auditProperty == null)
            {
                // check the database
                auditProperty = this.AuditProperties.FirstOrDefault(ap => ap.EntityName == entityName && ap.PropertyName == propertyName);

                if (auditProperty != null)
                {
                    this.currentAuditProperties.Add(auditProperty);
                }
            }

            // might return null
            return auditProperty;
        }

        /// <summary>
        /// Gets the audit property.
        /// </summary>
        /// <param name="relation">The relation.</param>
        /// <returns></returns>
        private TAuditProperty GetAuditProperty(System.Data.Entity.Core.Objects.DataClasses.IRelatedEnd relation)
        {
            Contract.Requires<ArgumentNullException>(relation != null, "relation");
            Contract.Ensures(Contract.Result<TAuditProperty>() != null);

            string relationName = relation.RelationshipSet.Name;
            string propertyName = string.Empty;

            // check our list
            TAuditProperty auditProperty = this.currentAuditProperties.FirstOrDefault(ap => ap.EntityName == relationName && ap.PropertyName == propertyName && ap.IsRelation == true);

            if (auditProperty == null)
            {
                // check the database
                auditProperty = this.AuditProperties.FirstOrDefault(ap => ap.EntityName == relationName && ap.PropertyName == propertyName && ap.IsRelation == true);

                if (auditProperty == null)
                {
                    // create it
                    auditProperty = new TAuditProperty() { EntityName = relationName, PropertyName = propertyName, PropertyType = string.Empty, IsRelation = true };
                }

                this.currentAuditProperties.Add(auditProperty);
            }

            return auditProperty;
        }

        /// <summary>
        /// Gets the entity entry from relation.
        /// </summary>
        /// <param name="relationEntry">The relation entry.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private ObjectStateEntry GetEntityEntryFromRelation(ObjectStateEntry relationEntry, int index)
        {
            Contract.Requires<ArgumentNullException>(relationEntry != null, "relationEntry");
            Contract.Ensures(Contract.Result<ObjectStateEntry>() != null);

            System.Data.Entity.Core.EntityKey firstKey;
            if (relationEntry.State == System.Data.Entity.EntityState.Deleted)
            {
                firstKey = (System.Data.Entity.Core.EntityKey)relationEntry.OriginalValues[index];  // added or detached objects cannot have OriginalValues
            }
            else
            {
                firstKey = (System.Data.Entity.Core.EntityKey)relationEntry.CurrentValues[index]; // deleted or detached objects cannot have CurrentValues
            }

            ObjectStateEntry entry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(firstKey);

            return entry;
        }
    }
}