// <copyright file="IClone.cs" company="Serhii Maksymchuk">
// Copyright (c) 2018 by Serhii Maksymchuk. All Rights Reserved.
// </copyright>

namespace BookLibraryBusinessLogic.Models
{
    /// <summary>
    /// Provides method to clone information
    /// from one object to another.
    /// </summary>
    /// <typeparam name="T">Type of source object.</typeparam>
    public interface IClone<T>
    {
        /// <summary>
        /// Clones the information from source
        /// to object which run the method.
        /// </summary>
        /// <param name="source">The source.</param>
        void Clone(T source);
    }
}
