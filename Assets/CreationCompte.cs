using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreationCompte : MonoBehaviour
{
    public InputField nomUtilisateurInput;
    public InputField motDePasseInput;

    // Méthode appelée lorsque le bouton "Créer un compte" est cliqué
    public void CreerCompte()
    {
        string nomUtilisateur = nomUtilisateurInput.text;
        string motDePasse = motDePasseInput.text;

        // Vérifier si les champs sont valides
        if (EstChampValide(nomUtilisateur) && EstChampValide(motDePasse))
        {
            // Créer un compte avec les données saisies
            CreerCompteUtilisateur(nomUtilisateur, motDePasse);
        }
        else
        {
            Debug.Log("Veuillez remplir tous les champs !");
        }
    }

    // Méthode pour vérifier si un champ est valide (non vide)
    private bool EstChampValide(string champ)
    {
        return !string.IsNullOrEmpty(champ);
    }

    // Méthode pour créer un compte utilisateur (vous pouvez remplacer cela par votre propre logique)
    private void CreerCompteUtilisateur(string nomUtilisateur, string motDePasse)
    {
        // Créer le compte utilisateur ici
        Debug.Log("Compte utilisateur créé : " + nomUtilisateur);
    }
}
