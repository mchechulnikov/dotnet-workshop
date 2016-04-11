package sorting.tests

import sorting.InsertionSorter
import org.junit.Assert
import org.junit.Test
import sorting.BubbleSorter
import sorting.ShellSorter
import sorting.Sorter

class SortersTests {
    private val sorters = listOf(
        InsertionSorter(),
        ShellSorter(),
        BubbleSorter()
    )

    @Test
    fun ascendingSort_simpleValidArray_isNotEmpty() {
        forEach { sorter ->
            var result = sorter.ascendingSort(mutableListOf(5, 4, 3, 2, 1))
            Assert.assertTrue(result.isNotEmpty())
            true
        }
    }

    @Test
    fun descendingSort_simpleValidArray_isNotEmpty() {
        forEach { sorter ->
            var result = sorter.descendingSort(mutableListOf(1, 2, 3, 4, 5))
            Assert.assertTrue(result.isNotEmpty())
            true
        }
    }

    @Test
    fun ascendingSort_simpleValidArray_validResult() {
        forEach { sorter ->
            var result = sorter.ascendingSort(mutableListOf(53, 45, 333, 45, 26, 111))
            for (index in result.indices) {
                if (index == result.indices.max()) break
                Assert.assertTrue(result[index] <= result[index + 1])
            }
            true
        }
    }

    @Test
    fun descendingSort_simpleValidArray_validResult() {
        forEach { sorter ->
            var result = sorter.descendingSort(mutableListOf(53, 45, 333, 45, 26, 111))
            for (index in result.indices) {
                if (index == result.indices.max()) break
                Assert.assertTrue(result[index] >= result[index + 1])
            }
            true
        }
    }

    private fun forEach(action: (Sorter) -> Boolean) {
        for (sorter in sorters) action(sorter)
    }
}