<#
.Synopsis

Handle compiling project to produce build artifacts for Release pipeline.

.Description

Steps for running in context of build server by an Azure DevOps agent as part of pipeline.

.PARAMETER Version

Semaphor version number for artifacts to be produced.

#>
param(
    [Parameter(Mandatory)]
    [string]$Version,

    [Parameter(Mandatory)]
    [ValidateSet('Debug','Release')]
    [string]$Configuration
)

Write-Host "** Run 'dotnet build' for Solution"
dotnet build --configuration $Configuration -p:Version=$Version