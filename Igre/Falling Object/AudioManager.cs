using System;
using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField] private AudioSource backgroundMusicSource;
   [SerializeField] private AudioSource soundEffectSource;
   
   [SerializeField] private AudioClip[] backgroundMusicClips;

   private void Awake()
   {
      StartCoroutine(PlayBackgroundMusic());
   }

   IEnumerator PlayBackgroundMusic()
   {
      for (int i = 0; i < backgroundMusicClips.Length; i++)
      {
         backgroundMusicSource.clip = backgroundMusicClips[i];
         backgroundMusicSource.Play();
         yield return new WaitForSeconds(backgroundMusicClips[i].length);
         
      }

      yield return PlayBackgroundMusic();
   }

   public void PlaySoundEffect()
   {
      soundEffectSource.Play();
   }
}
