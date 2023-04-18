# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project does adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [5.7.0] - 2023-04-18

- Latest metadata updates from 18th April 2023
- Fixes missing /mailBoxSettings paths on user objects (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1712)
- Adds response headers collection to ApiException object (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1755)
- Fixes missing query parameters for mailFolders api (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1814)

## [5.6.0] - 2023-04-12

- Latest metadata updates from 12th April 2023
- Fixes disposing of implicitly constructed BaseGraphRequestAdapter (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1724)

## [5.5.0] - 2023-04-06

### Changed 

- Fixes missing dateTime query parameters for bookingBusinesses (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1791)
- Fixes missing exapand clauses for calendars and contactFolder (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1788)
- Fixes return type when uploading small files to drive (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1718)
- Fixes inconsistencies in errors when using batch requests. (https://github.com/microsoftgraph/msgraph-sdk-dotnet/issues/1782)

### Added

- Latest metadata updates from 6th April 2023

## [5.4.0] - 2023-03-28

### Added

- Updates kiota abstraction library dependencies to reduce code size in generation.
- Metadata fixes for missing expand clauses for contact endpoints
- Latest metadata updates from 28th March 2023

## [5.3.0] - 2023-03-21

### Added

- Allows checking for status codes without parsing request bodies in batch requests (https://github.com/microsoftgraph/msgraph-sdk-dotnet-core/pull/626)
- Updates kiota abstraction library dependencies to fix serialization errors.
- Metadata fixes for missing expand clauses for messages,calendar and mailfolder endpoints
- Latest metadata updates from 21st March 2023

## [5.2.0] - 2023-03-14

### Added

- Updated core version to fix delta link parsing in pageiterator
- Updated core version to use range dependency for System.Text.Json and System.DiagnosticSource
- Latest metadata updates from 14th March 2023

## [5.1.0] - 2023-03-07

### Added

- Adds support for enhanced batch requests
- Latest metadata updates from 7th March 2023

## [5.0.0] - 2023-02-28

- GA release for Kiota SDK version

## [5.0.0-rc.5] - 2023-02-09

- [Breaking] Namespace and Request Builder renaming to align to paths defined in metadata (https://github.com/microsoft/kiota/issues/2209)
- Latest metadata updates from 7th February 2023 snapshot.

## [5.0.0-rc.4] - 2023-01-25

- Adds support for nullable reference types.
- Latest metadata updates from 24th January 2023 snapshot.

## [5.0.0-rc.3] - 2023-01-16

### Changed

- Fixed a regression where passing custom base url would not be reflected in the requests.
- Latest metadata updates from 17th January 2023 snapshot.

## [5.0.0-rc.2] - 2023-01-11

### Changed

- [Breaking] Renames `CreateXXXRequestInformation` methods to `ToXXXRequestInformation
- Adds `IAuthenticationProvider` parameter to GraphServiceClient constructor taking a httpClient instance.
- Latest metadata updates from 12th January 2023 snapshot

## [5.0.0-rc.1] - 2022-12-16

### Added

- Adds support for multi value headers
- Adds support for URI Form Encoded(`application/x-www-form-urlencoded`) serialization

### Changed

- Fixes Guid types represented as strings
- Latest metadata updates from 14th December 2022 snapshot

## [5.0.0-preview.14] - 2022-11-23

### Changed

- Adds baseUrl parameter to GraphServiceClient constructor to allow for easier updating of target endpoint
- Adds ItemWithPath for request builder to enable path retrieval of drive items
- Fix for default OdataType property in models causing errors from the API
- Latest metadata updates from 22nd November 2022 snapshot

## [5.0.0-preview.13] - 2022-10-18

### Changed

- Adds OdataDeltaLink property to collection responses for delta
- Changes the ResponeHandler parameter in request builders to be a RequestOption in dotnet [#1858](https://github.com/microsoft/kiota/issues/1858)
- Latest metadata updates from 18th October 2022 snapshot

## [5.0.0-preview.12] - 2022-09-29

### Added

### Changed

- Fixes incorrect types for collection types referencing enums - [Kiota #1846](https://github.com/microsoft/kiota/pull/1846)
- Fixes missing return object types for PATCH/POST/PUT calls - https://github.com/microsoftgraph/msgraph-beta-sdk-dotnet/issues/478
- Fixes missing QueryParameters for odata functions e.g delta 
- Latest metadata updates from 27th September 2022 snapshot

## [5.0.0-preview.11] - 2022-07-20

### Changed

- Latest metadata updates from 13th September 2022 snapshot
- MAUI support
- Fix incorrected nested paths that would point to incorrect request builders.

## [5.0.0-preview.10] - 2022-07-20

### Added

- Latest metadata updates from 19th July 2022 snapshot
- Fix for missing @odata.type properties in models

## [5.0.0-preview.9] - 2022-07-13

### Added

- Adds support for cancellation token support on large file uploads.

### Changed

- Latest metadata updates from 12th July 2022 snapshot
- Fixed incorrect casing of some properties on serialization [#483]

## [5.0.0-preview.8] - 2022-06-21

### Added

- Latest metadata updates from 21st June 2022 snapshot

### Changed

- Fixed missing derived models not directly referenced in openApi paths

## [5.0.0-preview.7] - 2022-06-09

### Added

- Latest metadata updates from 7th June 2022 snapshot
- Adds missing odata cast paths for the places API
- Adds functionality to send the relevant accept header request execution

### Changed

- Fixed missing response error mappings for OData functions/actions
- Fixed missing actions/functions defined on collection navigation properties
- Fixed missing derived models not directly referenced in openApi paths
- Fixed paging for odata functions/actions e.g. delta requests

## [5.0.0-preview.6] - 2022-06-02

### Added

- Adds missing odata cast paths to enable requests for specific kind of objects

### Changed

- Fixes exceptions on deserialization of payload that do not have @odata.type
- Fixes instances with missing key values for path parameters

## [5.0.0-preview.5] - 2022-05-20

### Changed

- [Breaking] Adds support CAE in the authentication provider
- [Breaking] Generated request parameter objects renamed to include http method name
- Enables the backing store to enable dirty tracking of objects

## [5.0.0-preview.4] - 2022-05-06

### Changed

- [Breaking] Request configuration revamp to support [Kiota #1494](https://github.com/microsoft/kiota/issues/1494)

## [5.0.0-preview.3] - 2022-04-20

### Changed

- Rename queryOptions parameters to be more descriptive

## [5.0.0-preview.2] - 2022-04-05

### Added

- Added support for vendor specific content types
- Added support for 204 no content responses

### Changed

- Update namespaces to be more discoverable (beta lib uses Microsoft.Graph.Beta namespace)
- Rename queryOptions parameters to be more descriptive

## [5.0.0-preview.1] - 2022-03-24

### Added

- Initial Kiota generated SDK version
