﻿#region Disclaimer / License

// Copyright (C) 2010, Jackie Ng
// https://github.com/jumpinjackie/mapguide-maestro
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
//
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
//

#endregion Disclaimer / License

using OSGeo.MapGuide.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OSGeo.MapGuide.MaestroAPI.Resource.Validation
{
    /// <summary>
    /// A "bucket" class that filters out redundant validation messages and allows for filtering the set of
    /// validation results by resource and specific validation status types
    /// </summary>
    /// <example>
    /// This example shows how a ValidationResultSet is used
    /// <code>
    /// <![CDATA[
    /// IResource resource;
    /// IServerConnection conn;
    /// ...
    /// var context = new ResourceValidationContext(conn);
    /// var issues = ResourceValidatorSet.Validate(context, item, false);
    /// var results = new ValidationResultSet(issues);
    /// ]]>
    /// </code>
    /// </example>
    public class ValidationResultSet
    {
        //HACK: Abusing the Key component of Dictionary<K, V> because there is no
        //Set<T> collection in .net fx 2.0!
        private Dictionary<string, Dictionary<ValidationIssue, ValidationIssue>> _issues;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultSet"/> class.
        /// </summary>
        public ValidationResultSet()
        {
            _issues = new Dictionary<string, Dictionary<ValidationIssue, ValidationIssue>>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultSet"/> class.
        /// </summary>
        /// <param name="issues">The issues.</param>
        public ValidationResultSet(IEnumerable<ValidationIssue> issues)
            : this()
        {
            Check.ArgumentNotNull(issues, nameof(issues));

            AddIssues(issues);
        }

        /// <summary>
        /// Gets the resource IDs
        /// </summary>
        /// <value>The resource IDs.</value>
        public string[] ResourceIDs => _issues.Keys.ToArray();

        /// <summary>
        /// Gets the issues for resource.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        /// <returns></returns>
        public ICollection<ValidationIssue> GetIssuesForResource(string resourceId)
        {
            Check.ArgumentNotEmpty(resourceId, nameof(resourceId));

            if (_issues.ContainsKey(resourceId))
                return _issues[resourceId].Keys;
            return new List<ValidationIssue>();
        }

        /// <summary>
        /// Gets the issues for resource.
        /// </summary>
        /// <param name="resourceId">The resource id.</param>
        /// <param name="statType">Type of the stat.</param>
        /// <returns></returns>
        public ICollection<ValidationIssue> GetIssuesForResource(string resourceId, ValidationStatus statType)
        {
            var issues = new List<ValidationIssue>();
            foreach (var issue in GetIssuesForResource(resourceId))
            {
                if (issue.Status == statType)
                    issues.Add(issue);
            }
            return issues;
        }

        /// <summary>
        /// Gets all issues.
        /// </summary>
        /// <returns></returns>
        public ValidationIssue[] GetAllIssues()
        {
            var issues = new List<ValidationIssue>();
            foreach (string resId in _issues.Keys)
            {
                issues.AddRange(_issues[resId].Keys);
            }
            return issues.ToArray();
        }

        /// <summary>
        /// Gets all issues filtered by the specified validation status types
        /// </summary>
        /// <param name="statTypes"></param>
        /// <returns></returns>
        public ValidationIssue[] GetAllIssues(params ValidationStatus[] statTypes)
        {
            var issues = new List<ValidationIssue>();
            foreach (string resId in _issues.Keys)
            {
                foreach (var issue in _issues[resId].Keys)
                {
                    if (Array.IndexOf(statTypes, issue.Status) >= 0)
                        issues.Add(issue);
                }
            }
            return issues.ToArray();
        }

        /// <summary>
        /// Adds the issue.
        /// </summary>
        /// <param name="issue">The issue.</param>
        public void AddIssue(ValidationIssue issue)
        {
            Check.ArgumentNotNull(issue, nameof(issue));
            Check.ArgumentNotNull(issue.Resource, $"{nameof(issue)}.{nameof(issue.Resource)}");
            Check.ArgumentNotEmpty(issue.Resource.ResourceID, $"{nameof(issue)}.{nameof(issue.Resource)}.{nameof(issue.Resource.ResourceID)}");

            if (!_issues.ContainsKey(issue.Resource.ResourceID))
                _issues[issue.Resource.ResourceID] = new Dictionary<ValidationIssue, ValidationIssue>();

            _issues[issue.Resource.ResourceID][issue] = issue;
        }

        /// <summary>
        /// Adds the issues.
        /// </summary>
        /// <param name="issues">The issues.</param>
        public void AddIssues(IEnumerable<ValidationIssue> issues)
        {
            if (issues == null)
                return;

            foreach (var issue in issues)
            {
                AddIssue(issue);
            }
        }
    }
}