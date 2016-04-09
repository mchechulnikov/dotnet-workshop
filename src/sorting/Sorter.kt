package sorting

interface Sorter {
    fun <T> sort(list: List<T>)

    fun <T> sort(list: List<T>): List<T>
}