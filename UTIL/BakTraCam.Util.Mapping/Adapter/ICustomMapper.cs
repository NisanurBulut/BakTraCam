using System;
using System.Collections.Generic;
using System.Text;

namespace BakTraCam.Util.Mapping.Adapter
{
    public interface ICustomMapper
    {
        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        // Type parameters:
        //   TSource:
        //     Source type to use, regardless of the runtime type
        //
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        TDestination Map<TSource, TDestination>(TSource source);

        //
        // Summary:
        //     Execute a mapping from the source object to the existing destination object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        // Type parameters:
        //   TSource:
        //     Source type to use
        //
        //   TDestination:
        //     Dsetination type
        //
        // Returns:
        //     The mapped destination object, same instance as the destination object
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
