   M S B A M L   `   `   `  ����I  EFittsLawTester, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FittsLawTesterFittsLawTester  5          FittsLawTester.Part1   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:FittsLawTester     5      X TXceed.Wpf.Toolkit, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        N� Title$  Part1��5	      .��5      � $��Center=�6   $��Center=�6(   $	��600��6C   $	��800��6P   .+�5   
   �� -   5         ��Name$ Amplitudes_List��5      $
��Left=�6+   $	��198��6F   $��149,244,0,0q�6S   $	��Top=�6h   $	��145��6�   6�   �� 5   
   -   5        $ Widths_List��5      $
��Left=�6'   $	��198��6B   $��330,244,0,0q�6O   $	��Top=�6d   $	��145��6|   6�   �� 5   
   -   5        $  Indices_of_Difficulty_List��5      $
��Left=�66   $	��198��6Q   $��509,244,0,0q�6^   $	��Top=�6s   $	��145��6�   �� 5   
   -   5         ��Name$ label_1��5      $��
Subject ID��6!   $
��Left=�66   $��
149,24,0,0q�6Q   $	��Top=�6e   $��26��6}   $	��145��6�   �� 5   
   -   5        $ label_2��5      $��Trials per condition��6!   $
��Left=�6@   $��
149,85,0,0q�6[   $	��Top=�6o   $��26��6�   $	��145��6�   �� 5   
   -   5        $ label_3��5      $��Amplitudes: (pixels)��6!   $
��Left=�6@   $��149,137,0,0q�6[   $	��Top=�6p   $��26��6�   $	��145��6�   �� 5   
   -   5        $ label_4��5      $��Widths: (pixels)��6!   $
��Left=�6<   $��330,137,0,0q�6W   $	��Top=�6l   $��26��6�   $	��145��6�    J� RenderTransformOrigin$ 1.043,1.983&�6�   �� 5   
   -   5        $ label_5��5      $��Indices of Difficulty��6!   $
��Left=�6A   $��509,137,0,0q�6\   $	��Top=�6q   $��26��6�   $	��189��6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5   
   -	   5        $��	SubjectID��5      �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ N0��6.   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 1X�6@      Maximum$
 1000X�6L   $
��Left=�6[   $��
330,24,0,0q�6v   $	��Top=�6�   $��26��6�   $��66��6�   6�     5   
   -
   5        $��Trials_Per_Condition��5      $ N0��69   $ 1X�6K   $	 100X�6W   $
��Left=�6e   $��
330,85,0,0q�6�   $	��Top=�6�   $��26��6�   $��66��6�   6�     5   
   -   5        $��
Amplitudes��5      $ N0��6/   $ 1X�6A   $	 800X�6M   $
��Left=�6[   $��149,196,0,0q�6v   $	��Top=�6�   $��26��6�   $��79��6�   6�     5   
   -   5        $��Widths��5      $ N0��6+   $ 1X�6=   $	 200X�6I   $
��Left=�6W   $��330,196,0,0q�6r   $	��Top=�6�   $��26��6�   $��79��6�   6�   �� 5   
   -   5        $ Total_Trials��5      $��Total trials: 0��6&   $
��Left=�6@   $��149,470,0,0q�6[   $	��Top=�6p   $	��122��6�   �� 5   
   -   5         ��Name$ OK��5      $��OK��6   $
��Left=�6*   $��400,470,0,0q�6E   $	��Top=�6Z   $��75��6r   6}   �� 5   
   -   5        $ Cancel��5      $��Cancel��6!   $
��Left=�62   $��509,470,0,0q�6M   $	��Top=�6b   $��75��6z   6�   �� 5   
   -   5        $ uniCount��5      $��(0 unique):��6"   $
��Left=�68   $��509,196,0,0q�6S   $	��Top=�6h   $��26��6�   $	��189��6�   �� 5   
   -   5        $ A_add��5      $��+��6    $
��Left=�6,   $��233,196,0,0q�6G   $	��Top=�6\   $��20��6t   $��26��6   {�6�   ��  �� ElementName$ 
Amplitudes��	 �� Path$	 Value��� 5   
   -   5        $ W_add��5      $��+��6    $
��Left=�6,   $��414,196,0,0q�6G   $	��Top=�6\   $��20��6t   $��26��6   6�   �� 5   
   -   5        $ A_delete��5      $��-��6#   $
��Left=�6/   $��258,196,0,0q�6J   $	��Top=�6_   $��20��6w   $��26��6�   6�   �� 5    
   -   5        $ W_delete��5       $��-��6#   $
��Left=�6/   $��439,196,0,0q�6J   $	��Top=�6_   $��20��6w   $��26��6�   6�   �� 5!   
   -   5        $ label_1_Copy��5!      $��(1-1000)��6&   $
��Left=�69   $��
509,24,0,0q�6T   $	��Top=�6h   $��26��6�   $	��145��6�   �� 5"   
   -   5        $ label_2_Copy��5"      $��(1-100)��6&   $
��Left=�68   $��
509,85,0,0q�6S   $	��Top=�6g   $��26��6   $	��145��6�   �� 5#   
   -   5        $ label_3_Copy��5#      $��(1-800)��6&   $
��Left=�68   $��149,163,0,0q�6S   $	��Top=�6h   $��26��6�   $	��145��6�   �� 5$   
   -   5        $ label_4_Copy��5$      $��(1-200)��6&   $
��Left=�68   $��330,163,0,0q�6S   $	��Top=�6h   $��26��6�   $	��145��6�   $ 1.043,1.983&�6�   5&      5'      