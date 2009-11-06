﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace CodeSmith.Data.Linq
{
    /// <summary>
    /// Provides for defering the execution of a query to a batch of queries.
    /// </summary>
    /// <typeparam name="T">The type for the future query.</typeparam>
    [DebuggerDisplay("IsLoaded={IsLoaded}, Value={ValueForDebugDisplay}")]
    [DebuggerTypeProxy(typeof(FutureValueDebugView<>))]
    public class FutureValue<T> : FutureQueryBase<T>
    {
        private T _underlyingValue = default(T);
        private bool _hasValue = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CodeSmith.Data.Linq.FutureValue`1"/> class.
        /// </summary>
        /// <param name="query">The query source to use when materializing.</param>
        /// <param name="loadAction">The action to execute when the query is accessed.</param>
        public FutureValue(IQueryable query, Action loadAction)
            : base(query, loadAction)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CodeSmith.Data.Linq.FutureValue`1"/> class.
        /// </summary>
        /// <param name="underlyingValue">The underlying value.</param>
        public FutureValue(T underlyingValue)
            : base(null, null)
        {
            _underlyingValue = underlyingValue;
            _hasValue = true;
        }

        /// <summary>
        /// Gets or sets the value assigned to or loaded by the query.
        /// </summary>
        /// <returns>
        /// The value of this deferred property.
        /// </returns>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public T Value
        {
            get
            {
                if (!_hasValue)
                {
                    _hasValue = true;
                    var result = GetResult();
                    if (result == null)
                        return _underlyingValue;

                    _underlyingValue = result.FirstOrDefault();
                }

                return _underlyingValue;
            }
            set
            {
                _underlyingValue = value;
                _hasValue = true;
            }
        }

        #region Debug Proxy
        internal T ValueForDebugDisplay
        {
            get { return _underlyingValue; }
        }

        internal sealed class FutureValueDebugView<TDebug>
        {
            private readonly FutureValue<TDebug> _future;

            public FutureValueDebugView(FutureValue<TDebug> future)
            {
                _future = future;
            }

            public TDebug Value
            {
                get { return _future.ValueForDebugDisplay; }
            }

            public bool IsLoaded
            {
                get { return _future.IsLoaded; }
            }

            public IQueryable Query
            {
                get { return ((IFutureQuery)_future).Query; }
            }
        }
        #endregion
    }



}