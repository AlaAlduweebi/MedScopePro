using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ProMedScope.ViewModels.Patient;

/// <summary>
/// Repräsentiert das ViewModel der Patientenansicht.
/// </summary>
public class PatientViewModel : ObservableObject
{
    /// <summary>
    /// Enthält die geöffneten Patienten im Workspace.
    /// </summary>
    public ObservableCollection<string> OpenPatients { get; } =
    [
        "Virginia Rossi",
        "Marco Bianchi",
        "Giulia Romano",
        "Sofia Esposito"
    ];
}