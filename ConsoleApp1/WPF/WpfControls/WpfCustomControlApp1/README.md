# README

WPF4.5���� ����54 �u�J�X�^���R���g���[���v

https://blog.okazuki.jp/entry/2014/09/08/221209


UserControl�ŁA�Ǝ��R���g���[���������@���Љ�܂������A
UserControl�ł͂ł��Ȃ����Ƃ�����܂��B
ControlTemplate�֑Ή��ł��B

ControlTemplate�֑Ή��������S��WPF�̓Ǝ��R���g���[�������ɂ́A
���ꂩ��Љ��J�X�^���R���g���[�����쐬����K�v������܂��B

�J�X�^���R���g���[���́A�V�K�쐬�̃J�X�^���R���g���[���iWPF�j����쐬���܂��B
�쐬����ƁA�N���X��1��Themes�t�H���_�̒���Generic.xaml���쐬����܂��B
����Generic.xaml���ɃR���g���[���̃f�t�H���g��Style���`���ăR���g���[�����쐬���܂��B

�R���g���[���̃f�t�H���g��Style�̃L�[�̓N���X�̐ÓI�R���X�g���N�^��
�ȉ��̂悤��DefaultStyleKey�ˑ��֌W�v���p�e�B�̃f�t�H���g�l���㏑�����邱�ƂŎw�肳��Ă��܂��B

```c#
static NumericUpDown()
{
    DefaultStyleKeyProperty.OverrideMetadata(typeof(NumericUpDown), 
new FrameworkPropertyMetadata(typeof(NumericUpDown)));
}
```
