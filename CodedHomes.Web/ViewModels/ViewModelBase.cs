using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodedHomes.Web.Models;

namespace CodedHomes.Web.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ViewModelBase
    {
        /// <summary>
        /// The _can edit
        /// </summary>
        private bool? _canEdit = null;
        /// <summary>
        /// The _can delete
        /// </summary>
        private bool? _canDelete = null;

        /// <summary>
        /// The _evaluator
        /// </summary>
        private RoleEvaluator _evaluator = new RoleEvaluator();

        /// <summary>
        /// Gets a value indicating whether [can edit].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can edit]; otherwise, <c>false</c>.
        /// </value>
        public bool CanEdit
        {
            get
            {
                if (!this._canEdit.HasValue)
                {
                    this._canEdit = this._evaluator.CanEdit;
                }

                return this._canEdit.Value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [can delete].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [can delete]; otherwise, <c>false</c>.
        /// </value>
        public bool CanDelete
        {
            get
            {
                if (!this._canDelete.HasValue)
                {
                    this._canDelete = this._evaluator.CanDelete;
                }

                return this._canDelete.Value;
            }
        }
    }
}